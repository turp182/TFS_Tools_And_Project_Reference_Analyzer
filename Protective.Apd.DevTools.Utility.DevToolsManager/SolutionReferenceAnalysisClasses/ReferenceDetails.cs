using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevToolsAndReferenceAnalyzer.SolutionReferenceAnalysisClasses
{
    /// <summary>
    /// Class containing details about a specific project reference (project agnostic).
    /// </summary>
    public sealed class ReferenceDetails : IEquatable<ReferenceDetails>
    {
        public string AssemblyName { get; set; }
        public string FullyQualifiedName { get; set; }

        public ReferenceType ReferenceType { get; set; }
        public string Path { get; set; }
        public string RequiredTargetFramework { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance. 
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return AssemblyName;
        }

        public override int GetHashCode()
        {
            //// hash algoritm info:
            //// http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode

            unchecked
            {
                int hash = 17;

                if (!string.IsNullOrEmpty(AssemblyName))
                {
                    hash = (hash * 23) + AssemblyName.GetHashCode();
                }

                if (!string.IsNullOrEmpty(FullyQualifiedName))
                {
                    hash = (hash * 23) + FullyQualifiedName.GetHashCode();
                }

                hash = (hash * 23) + ReferenceType.GetHashCode();

                if (!string.IsNullOrEmpty(RequiredTargetFramework))
                {
                    hash = (hash * 23) + RequiredTargetFramework.GetHashCode();
                }

                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            ReferenceDetails details = obj as ReferenceDetails;

            return base.Equals(details);
        }

        #region IEquatable<ReferenceDetails> Members

        public bool Equals(ReferenceDetails other)
        {
            if (this.GetHashCode() == other.GetHashCode())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
