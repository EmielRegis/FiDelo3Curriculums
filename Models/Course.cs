using FiDeLo3.Resources.Curriculums.Contract;

namespace FiDeLo3.Resources.Curriculums.Models
{
    /// <summary>
    /// A course in study plan
    /// </summary>
    public class Course : ICourse
    {
        public int Id { get; set; }
        /// <summary>
        /// Name of the course
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates if the couse has an Exam
        /// </summary>
        public bool HasExam { get; set; }

        /// <summary>
        /// How many hours of lecture the course has.
        /// </summary>
        public uint LectureHours { get; set; }

        /// <summary>
        /// How many hours of classes the course has.
        /// </summary>
        public uint ClassesHours { get; set; }

        /// <summary>
        /// How many hours of laboratories the course has.
        /// </summary>
        public uint LaboratoriesHours { get; set; }

        /// <summary>
        /// How many hours of project the course has.
        /// </summary>
        public uint ProjectHours { get; set; }

        /// <summary>
        /// How many ECTS credits the course has.
        /// </summary>
        public ushort EctsPoints { get; set; }

        /// <summary>
        /// Faculty type which realize the course.
        /// </summary>
        public CourseProviderType CourseProvider { get; set; }
    }
}
