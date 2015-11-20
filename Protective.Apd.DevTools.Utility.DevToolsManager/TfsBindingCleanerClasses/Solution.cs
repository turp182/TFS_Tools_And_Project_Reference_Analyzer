using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DevToolsAndReferenceAnalyzer.TfsBindingCleanerClasses
{
    /// <summary>
    /// Class representing a Visual Studio Solution.
    /// </summary>
    public sealed class Solution
    {
        private static readonly Type _SolutionParser;
        private static readonly PropertyInfo _SolutionParser_solutionReader;
        private static readonly MethodInfo _SolutionParser_ParseSolution;
        private static readonly PropertyInfo _SolutionParser_Projects;

        /// <summary>
        /// Initializes static members of the <see cref="Solution"/> class.
        /// </summary>
        static Solution()
        {
            _SolutionParser = Type.GetType("Microsoft.Build.Construction.SolutionParser, Microsoft.Build, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);
            if (_SolutionParser != null)
            {
                MethodInfo[] methods = _SolutionParser.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

                _SolutionParser_solutionReader = _SolutionParser.GetProperty("SolutionReader", BindingFlags.NonPublic | BindingFlags.Instance);
                _SolutionParser_Projects = _SolutionParser.GetProperty("Projects", BindingFlags.NonPublic | BindingFlags.Instance);
                _SolutionParser_ParseSolution = _SolutionParser.GetMethod("ParseSolution", BindingFlags.NonPublic | BindingFlags.Instance);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Solution"/> class.
        /// </summary>
        /// <param name="solutionFileName">Name of the solution file.</param>
        /// <exception cref="System.InvalidOperationException">Can not find type 'Microsoft.Build.Construction.SolutionParser' are you missing a assembly reference to 'Microsoft.Build.dll'?</exception>
        public Solution(string solutionFileName)
        {
            if (!string.IsNullOrEmpty(Path.GetDirectoryName(solutionFileName)))
            {
                Environment.CurrentDirectory = Path.GetDirectoryName(solutionFileName);
            }

            if (_SolutionParser == null)
            {
                throw new InvalidOperationException("Can not find type 'Microsoft.Build.Construction.SolutionParser' are you missing a assembly reference to 'Microsoft.Build.dll'?");
            }
            var solutionParser = _SolutionParser.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).First().Invoke(null);
            using (var streamReader = new StreamReader(solutionFileName))
            {
                _SolutionParser_solutionReader.SetValue(solutionParser, streamReader, null);
                _SolutionParser_ParseSolution.Invoke(solutionParser, null);
            }

            //// debug info to show what methods and properties are available
            ////MethodInfo[] methodInfos = s_SolutionParser.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            ////List<string> methodInformation = methodInfos.Select(method => string.Format("{0}~{1}~{2}", method.MemberType.ToString(), method.Name, method.ReturnType.ToString())).ToList();
            ////string typeInformation = string.Join(Environment.NewLine, methodInformation);
            ////PropertyInfo[] propertyInfos = s_SolutionParser.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
            ////List<string> propertyInformation = propertyInfos.Select(property => string.Format("{0}~{1}~{2}", property.MemberType.ToString(), property.Name, property.PropertyType.ToString())).ToList();
            ////typeInformation += string.Join(Environment.NewLine, propertyInformation);

            var projects = new List<SolutionProject>();
            var array = (Array)_SolutionParser_Projects.GetValue(solutionParser, null);

            for (int i = 0; i < array.Length; i++)
            {
                SolutionProject project = new SolutionProject(array.GetValue(i));
                string projectFilePath = Path.GetFullPath(project.RelativePath);

                if (File.Exists(projectFilePath))
                {
                    projects.Add(project);
                }
            }
            this.Projects = projects;
        }

        public List<SolutionProject> Projects { get; private set; }
    }
}
