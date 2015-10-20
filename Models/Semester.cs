using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FiDeLo3.Resources.Curriculums.Models
{
    public class Semester
    {
        public int Id { get; set; }
        
        public ICollection<Course> Courses { get; set; }

        public bool ValidateCredits()
        {
            return Courses.Sum(course => course.EctsPoints) == 30; //TODO: parameter
        }
    }
}
