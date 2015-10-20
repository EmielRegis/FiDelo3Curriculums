using System.Collections.Generic;
using FiDeLo3.Resources.Curriculums.Contract;

namespace FiDeLo3.Resources.Curriculums.Models
{
    public class Curriculum
    {
        public int Id { get; set; }
        /// <summary>
        /// Name of the course
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates if the couse has an Exam
        /// </summary>
        
        public virtual ICollection<Semester> Semesters { get; set; }
       
    }
}
