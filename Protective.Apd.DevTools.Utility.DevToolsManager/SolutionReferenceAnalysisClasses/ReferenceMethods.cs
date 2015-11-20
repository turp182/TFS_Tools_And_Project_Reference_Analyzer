using DevToolsAndReferenceAnalyzer.TfsBindingCleanerClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace DevToolsAndReferenceAnalyzer.SolutionReferenceAnalysisClasses
{
    /// <summary>
    /// Class that implements the Reference Analysis feature functionality.
    /// </summary>
    public static class ReferenceMethods
    {
        /// <summary>
        /// Gets all of the reference details for a given project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>A ProjectReferenceInfo object.</returns>
        public static ProjectReferenceInfo GetReferenceDetailsForProject(SolutionProject project)
        {
            var projectReferenceInfo = new ProjectReferenceInfo(project);

            string projectFilePath = Path.GetFullPath(project.RelativePath);

            XmlDocument projectXml = new XmlDocument();

            projectXml.Load(projectFilePath);

            // set environment directory to the folder level so relative paths are accurate
            string projectFolderPath = Path.GetDirectoryName(projectFilePath);
            Environment.CurrentDirectory = projectFolderPath;

            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(projectXml.NameTable);
            namespaceManager.AddNamespace("ns1", "http://schemas.microsoft.com/developer/msbuild/2003");

            // Project References
            XmlNodeList nodeList = projectXml.SelectNodes("//ns1:ItemGroup/ns1:ProjectReference", namespaceManager);
            foreach (XmlNode node in nodeList)
            {
                ReferenceDetails details = GetReferenceDetails(node, ReferenceType.Project, namespaceManager);
                projectReferenceInfo.ProjectReferences.Add(details);
            }

            // Framework and Library References
            nodeList = projectXml.SelectNodes("//ns1:ItemGroup/ns1:Reference", namespaceManager);
            foreach (XmlNode node in nodeList)
            {
                ReferenceDetails details = GetReferenceDetails(node, ReferenceType.Unknown, namespaceManager);

                if (details.ReferenceType == ReferenceType.Framework)
                {
                    projectReferenceInfo.FrameworkReferences.Add(details);
                }
                else if (details.ReferenceType == ReferenceType.Library)
                {
                    projectReferenceInfo.LibraryReferences.Add(details);
                }
            }
            return projectReferenceInfo;
        }

        /// <summary>
        /// Performs the reference analysis.
        /// </summary>
        /// <param name="projectReferenceInfos">The project reference infos.</param>
        /// <returns>A string containing the results of the reference analysis.</returns>
        public static string AnalyzeReferences(List<ProjectReferenceInfo> projectReferenceInfos)
        {
            string results = string.Empty;

            results += CheckFrameworkAssembliesForPossibleLibrarySuspects(projectReferenceInfos);
            results += CheckForAssembliesWithDifferentVersionsAndOrDifferentPhysicalPaths(projectReferenceInfos);

            if (results.Length == 0)
            {
                results = "No Reference issues identified.";
            }

            return results;
        }

        /// <summary>
        /// Gets the details for a reference from a node of Project XML.
        /// </summary>
        /// <param name="referenceNode">The reference node.</param>
        /// <param name="referenceType">Type of the reference.</param>
        /// <param name="namespaceManager">The namespace manager.</param>
        /// <returns>A ReferenceDetails object.</returns>
        private static ReferenceDetails GetReferenceDetails(XmlNode referenceNode, ReferenceType referenceType, XmlNamespaceManager namespaceManager)
        {
            var details = new ReferenceDetails();

            if (referenceType == ReferenceType.Project)
            {
                details.ReferenceType = referenceType;

                if (referenceNode.SelectSingleNode("ns1:Name", namespaceManager) != null)
                {
                    details.AssemblyName = referenceNode.SelectSingleNode("ns1:Name", namespaceManager).InnerText;
                }

                string path = referenceNode.Attributes["Include"].Value;
                path = Path.GetFullPath(path);

                details.Path = path;
            }
            else // consider it unknown
            {
                // library references will either have a HintPath or a Content/@Include element with the path to the reference file
                bool isLibraryReference = false;

                // get the namespace value
                string includeAttributeValue = referenceNode.Attributes["Include"].Value;
                string assemblyName = includeAttributeValue.Split(',')[0];

                details.AssemblyName = assemblyName;
                details.FullyQualifiedName = includeAttributeValue;

                // check for an Content Include reference - if there is one then this is a library reference
                if (referenceNode.OwnerDocument.SelectSingleNode("//ns1:Content[@Include[contains(.,'" + assemblyName + ".dll')]]", namespaceManager) != null)
                {
                    XmlNode contentNode = referenceNode.OwnerDocument.SelectSingleNode("//ns1:Content[@Include[contains(.,'" + assemblyName + ".dll')]]", namespaceManager);
                    string path = contentNode.Attributes["Include"].Value;

                    details.Path = Path.GetFullPath(path);

                    isLibraryReference = true;
                }
                //// check for HintPath
                if (!isLibraryReference && referenceNode.SelectSingleNode("ns1:HintPath", namespaceManager) != null)
                {
                    isLibraryReference = true;
                    string path = referenceNode.SelectSingleNode("ns1:HintPath", namespaceManager).InnerText;
                    path = Path.GetFullPath(path);

                    details.Path = path;
                }

                if (referenceNode.SelectSingleNode("ns1:RequiredTargetFramework", namespaceManager) != null)
                {
                    details.RequiredTargetFramework = referenceNode.SelectSingleNode("ns1:RequiredTargetFramework", namespaceManager).InnerText;
                }

                if (isLibraryReference)
                {
                    details.ReferenceType = ReferenceType.Library;
                }
                else
                {
                    details.ReferenceType = ReferenceType.Framework;
                }
            }

            return details;
        }

        /// <summary>
        /// Checks the list of Framework assemblies for potential Library references.
        /// </summary>
        /// <param name="projectReferenceInfos">The project reference infos.</param>
        /// <returns>A string with the results of the analysis.</returns>
        private static string CheckFrameworkAssembliesForPossibleLibrarySuspects(List<ProjectReferenceInfo> projectReferenceInfos)
        {
            string results = string.Empty;

            List<ReferenceDetails> allFrameworkReferences = projectReferenceInfos.SelectMany(info => info.FrameworkReferences).Distinct().OrderBy(info => info.AssemblyName).ToList();

            List<ReferenceDetails> mismatchedAssemblyAndFullyQualifiedNames = (from referenceDetails in allFrameworkReferences
                                                                                   where referenceDetails.AssemblyName != referenceDetails.FullyQualifiedName
                                                                                    && referenceDetails.AssemblyName.IndexOf("System") != 0
                                                                                   select referenceDetails).ToList();

            if (mismatchedAssemblyAndFullyQualifiedNames.Count > 0)
            {
                results += "Found Framework References that may actually be Library References" + Environment.NewLine;
                results += "The Assembly Name doesn't match the Fully Qualified Name, so they aren't part of the core Framework." + Environment.NewLine;
                results += "They are in the GAC but it is not guaranteed that a server will have them." + Environment.NewLine;
                results += "--------------------------------------------------------------------------" + Environment.NewLine + Environment.NewLine;
            }

            foreach (ReferenceDetails details in mismatchedAssemblyAndFullyQualifiedNames)
            {
                results += " - Assembly Name: " + details.AssemblyName + Environment.NewLine;
                results += "    - Fully Qualified Name: " + details.FullyQualifiedName + Environment.NewLine + Environment.NewLine;
            }

            return results;
        }

        /// <summary>
        /// Checks the complete set of assemblies for those with the same Assembly Name but differing Fully Qualified Names or differing Physical Paths.
        /// </summary>
        /// <param name="projectReferenceInfos">The project reference infos.</param>
        /// <returns>A string with the results of the analysis.</returns>
        private static string CheckForAssembliesWithDifferentVersionsAndOrDifferentPhysicalPaths(List<ProjectReferenceInfo> projectReferenceInfos)
        {
            string results = string.Empty;

            List<ReferenceDetails> allReferences = (from projectReferenceInfo in projectReferenceInfos
                                                     from referenceDetails in projectReferenceInfo.AllReferences
                                                     select referenceDetails).Distinct().OrderBy(info => info.AssemblyName).ToList();

            var referencesHandled = new List<string>();

            foreach (ReferenceDetails details in allReferences)
            {
                List<ReferenceDetails> differentVersions = (from aDetails in allReferences
                            where aDetails.AssemblyName == details.AssemblyName
                                && !referencesHandled.Contains(details.AssemblyName)
                                && (aDetails.FullyQualifiedName != details.FullyQualifiedName                                
                                || aDetails.Path != details.Path)
                                select aDetails).ToList();
                if (differentVersions.Count > 0)
                {
                    results += "Assembly with Differing Fully Qualified Names or Physical Paths Identified: " + details.AssemblyName + Environment.NewLine;
                    results += "-----------------------------------------------------------" + Environment.NewLine + Environment.NewLine;

                    results += "Assembly #1 Details:" + Environment.NewLine;
                    results += "-------------------------------" + Environment.NewLine;
                    results += " - Reference Type: " + details.ReferenceType.ToString() + Environment.NewLine;
                    results += " - Fully Qualified Name: " + details.FullyQualifiedName + Environment.NewLine;
                    results += " - Path: " + details.Path + Environment.NewLine;
                    results += " - Required Target Framework: " + details.RequiredTargetFramework + Environment.NewLine;
                    
                    results += " - Projects Referencing:" + Environment.NewLine;
                    results += " - -------------------------" + Environment.NewLine;
                    List<string> projectsReferencing = GetProjectNamesUsingSpecificReference(details, projectReferenceInfos);
                    results += projectsReferencing.Aggregate((i, j) => i + Environment.NewLine + j);
                    results += Environment.NewLine + Environment.NewLine;

                    int index = 2;

                    foreach (ReferenceDetails differentDetails in differentVersions)
                    {
                        results += "Assembly #" + index + " Details:" + Environment.NewLine;
                        results += "-------------------------------" + Environment.NewLine;
                        results += " - Reference Type: " + differentDetails.ReferenceType.ToString() + Environment.NewLine;
                        results += " - Fully Qualified Name: " + differentDetails.FullyQualifiedName + Environment.NewLine;
                        results += " - Path: " + differentDetails.Path + Environment.NewLine;
                        results += " - Required Target Framework: " + differentDetails.RequiredTargetFramework + Environment.NewLine;

                        results += " - Projects Referencing:" + Environment.NewLine;
                        results += " - -------------------------" + Environment.NewLine;
                        List<string> projectsReferencing2 = GetProjectNamesUsingSpecificReference(differentDetails, projectReferenceInfos);
                        results += projectsReferencing2.Aggregate((i, j) => i + Environment.NewLine + j);
                        results += Environment.NewLine + Environment.NewLine;

                        index++;
                    }

                    referencesHandled.Add(details.AssemblyName);
                }
            }
            return results;
        }

        /// <summary>
        /// Gets the list of projects that are using a specific reference (by unique reference, not just Assembly Name).
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="projectReferenceInfos">The project reference infos.</param>
        /// <returns>A list of project names.</returns>
        private static List<string> GetProjectNamesUsingSpecificReference(ReferenceDetails details, List<ProjectReferenceInfo> projectReferenceInfos)
        {
            List<string> projectNames = (from project in projectReferenceInfos
                                         where project.AllReferences.Contains(details)
                                         select project.ProjectName).OrderBy(p => p).ToList();

            return projectNames;
        }
    }
}
