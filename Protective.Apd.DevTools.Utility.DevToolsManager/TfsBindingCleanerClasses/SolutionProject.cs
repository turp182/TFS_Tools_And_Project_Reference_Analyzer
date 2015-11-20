using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace DevToolsAndReferenceAnalyzer.TfsBindingCleanerClasses
{
    /// <summary>
    /// Class representing a Visual Studio Project contained in a Solution.
    /// </summary>
    public sealed class SolutionProject
    {
        private static readonly Type _ProjectInSolution;
        private static readonly PropertyInfo _ProjectInSolution_ProjectName;
        private static readonly PropertyInfo _ProjectInSolution_RelativePath;
        private static readonly PropertyInfo _ProjectInSolution_ProjectGuid;

        /// <summary>
        /// Initializes static members of the <see cref="SolutionProject"/> class.
        /// </summary>
        static SolutionProject()
        {
            _ProjectInSolution = Type.GetType("Microsoft.Build.Construction.ProjectInSolution, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
            if (_ProjectInSolution != null)
            {
                PropertyInfo[] infos = _ProjectInSolution.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                FieldInfo[] fieldInfos = _ProjectInSolution.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                MemberInfo[] memberInfos = _ProjectInSolution.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                
                _ProjectInSolution_ProjectName = _ProjectInSolution.GetProperty("ProjectName", BindingFlags.NonPublic | BindingFlags.Instance);
                _ProjectInSolution_RelativePath = _ProjectInSolution.GetProperty("RelativePath", BindingFlags.NonPublic | BindingFlags.Instance);
                _ProjectInSolution_ProjectGuid = _ProjectInSolution.GetProperty("ProjectGuid", BindingFlags.NonPublic | BindingFlags.Instance);               
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionProject"/> class.
        /// </summary>
        /// <param name="solutionProject">The solution project.</param>
        public SolutionProject(object solutionProject)
        {
            //// debug info to show what methods and properties are available
            ////MethodInfo[] methodInfos = s_ProjectInSolution.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            ////List<string> methodInformation = methodInfos.Select(method => string.Format("{0}~{1}~{2}", method.MemberType.ToString(), method.Name, method.ReturnType.ToString())).ToList();
            ////string typeInformation = string.Join(Environment.NewLine, methodInformation);
            ////PropertyInfo[] propertyInfos = s_ProjectInSolution.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
            ////List<string> propertyInformation = propertyInfos.Select(property => string.Format("{0}~{1}~{2}", property.MemberType.ToString(), property.Name, property.PropertyType.ToString())).ToList();
            ////typeInformation += string.Join(Environment.NewLine, propertyInformation);            

            this.ProjectName = _ProjectInSolution_ProjectName.GetValue(solutionProject, null) as string;
            this.RelativePath = _ProjectInSolution_RelativePath.GetValue(solutionProject, null) as string;
            this.ProjectGuid = _ProjectInSolution_ProjectGuid.GetValue(solutionProject, null) as string;

            var projectXml = new XmlDocument();
            string fullProjectPath = Path.GetFullPath(this.RelativePath);

            if (File.Exists(fullProjectPath))
            {
                projectXml.Load(fullProjectPath);

                XmlNamespaceManager namespaceManager = new XmlNamespaceManager(projectXml.NameTable);
                namespaceManager.AddNamespace("ns1", "http://schemas.microsoft.com/developer/msbuild/2003");

                XmlNode outputTypeNode = projectXml.SelectSingleNode("//ns1:OutputType", namespaceManager);
                this.OutputType = outputTypeNode.InnerText;

                XmlNode assemblyNameNode = projectXml.SelectSingleNode("//ns1:AssemblyName", namespaceManager);
                this.AssemblyName = assemblyNameNode.InnerText;
            }
        }

        public string ProjectName { get; private set; }
        public string RelativePath { get; private set; }
        public string ProjectGuid { get; private set; }
        
        public string OutputType { get; private set; }
        public string AssemblyName { get; private set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return ProjectName;
        }
    }
}
