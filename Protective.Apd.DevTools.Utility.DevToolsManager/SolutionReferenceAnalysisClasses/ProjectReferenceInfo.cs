using DevToolsAndReferenceAnalyzer.TfsBindingCleanerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevToolsAndReferenceAnalyzer.SolutionReferenceAnalysisClasses
{
    /// <summary>
    /// Class containing project reference information.
    /// </summary>
    public sealed class ProjectReferenceInfo
    {
        public ProjectReferenceInfo(SolutionProject project)
        {
            this.ProjectName = project.ProjectName;
            this.RelativePath = project.RelativePath;

            ProjectReferences = new List<ReferenceDetails>();
            FrameworkReferences = new List<ReferenceDetails>();
            LibraryReferences = new List<ReferenceDetails>();
        }

        public string ProjectName { get; set; }
        public string RelativePath { get; set; }

        public List<ReferenceDetails> ProjectReferences { get; set; }

        public List<ReferenceDetails> FrameworkReferences { get; set; }

        public List<ReferenceDetails> LibraryReferences { get; set; }

        public List<ReferenceDetails> AllReferences
        {
            get
            {
                List<ReferenceDetails> allReferences = ProjectReferences;
                allReferences = allReferences.Union(FrameworkReferences).ToList();
                allReferences = allReferences.Union(LibraryReferences).ToList();

                return allReferences;
            }
        }

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
