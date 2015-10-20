namespace FiDeLo3.Resources.Curriculums.Contract
{
    public enum CourseProviderType
    {
        /// <summary>
        /// Course realized by home faculty
        /// </summary>
        Internal = 0,

        /// <summary>
        /// Course realized by external faculty; rules are not precised 
        /// </summary>
        External = 1,

        /// <summary>
        /// Course realized by CJOiK faculty. Language courses.
        /// </summary>
        LanguageDepratment = 2,

        /// <summary>
        /// Course relized by Centrum Sportu (Sport Center).
        /// </summary>
        SportsDepartment = 3,
    }
}