
namespace FiDeLo3.Resources.Curriculums.Contract
{
    public interface ICourse
    {
       int Id {get; set; }
        /// <summary>
        /// Name of the course
        /// </summary>
       string Name { get; set; }

        /// <summary>
        /// Indicates if the couse has an Exam
        /// </summary>
        bool HasExam { get; set; }

        /// <summary>
        /// How many hours of lecture the course has.
        /// </summary>
        uint LectureHours { get; set; }

        /// <summary>
        /// How many hours of classes the course has.
        /// </summary>
        uint ClassesHours { get; set; }

        /// <summary>
        /// How many hours of laboratories the course has.
        /// </summary>
        uint LaboratoriesHours { get; set; }

        /// <summary>
        /// How many hours of project the course has.
        /// </summary>
        uint ProjectHours { get; set; }

        /// <summary>
        /// How many ECTS credits the course has.
        /// </summary>
        ushort EctsPoints { get; set; }

        /// <summary>
        /// Faculty type which realize the course.
        /// </summary>
        CourseProviderType CourseProvider { get; set; }
    }
}