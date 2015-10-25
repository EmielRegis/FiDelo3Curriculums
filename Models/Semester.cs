using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace FiDeLo3.Resources.Curriculums.Models
{
    public class Semester
    {
        public Semester()
        {
            Courses = new List<Course>();
        }
        
        public int Id { get; set; }
        
        public uint OrderNumber { get; set; }
        
        public ICollection<Course> Courses { get; set; }
        
        public int CurriculumId { get; set; }
        [JsonIgnore]
        public Curriculum Curriculum { get; set; }

        public bool ValidateCredits()
        {
            return Courses.Sum(course => course.EctsPoints) == 30; //TODO: parameter
        }
    }
}
