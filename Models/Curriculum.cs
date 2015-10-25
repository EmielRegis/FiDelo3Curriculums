using System.Collections.Generic;
using FiDeLo3.Resources.Curriculums.Contract;

namespace FiDeLo3.Resources.Curriculums.Models
{
    public class Curriculum
    {
        public Curriculum()
        {
            Semesters = new List<Semester>();
        }
        
        public int Id { get; set; }
        /// <summary>
        /// Name of the course
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates if the couse has an Exam
        /// </summary>
        
        public bool IsFullTime { get; set; }
        
        public uint CycleOfStudies 
        {
             get
             {
                 return _cycleOfStudies;
             }
             
             set 
             {
                 if (value < 3)
                    _cycleOfStudies = value;
             }
        }
        private uint _cycleOfStudies;
        
        public ICollection<Semester> Semesters { get; set; }
       
    }
}
