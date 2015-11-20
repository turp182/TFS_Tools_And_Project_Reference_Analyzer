namespace DevToolsAndReferenceAnalyzer.SolutionReferenceAnalysisClasses
{
    /// <summary>
    /// Enumeration containing the different types of References a Project can have.
    /// </summary>
    public enum ReferenceType
    {
        /// <summary>
        /// Unknown type, used as a default prior to the type actually being known.
        /// </summary>
        Unknown,
        
        /// <summary>
        /// A Project reference to another Project in the same Solution.
        /// </summary>
        Project,
        
        /// <summary>
        /// A Framework reference to a core .Net Framework assembly or another assembly in the Global Assembly Cache.
        /// </summary>
        Framework,
        
        /// <summary>
        /// A Library reference to an external dll/exe that is not in the Global Assembly Cache.
        /// </summary>
        Library
    }
}
