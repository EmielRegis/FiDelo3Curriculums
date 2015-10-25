using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using FiDeLo3.Resources.Curriculums.Contract;
using FiDeLo3.Resources.Curriculums.Models;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Cors.Core;

namespace FiDeLo3.Resources.Curriculums.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class CurriculumsController : Controller
    {
        private readonly CurriculumsDbContext _dbContext;
        private readonly ILogger<CurriculumsController> _logger;
        
        public CurriculumsController(CurriculumsDbContext curriculumDbContext, ILogger<CurriculumsController> logger)
        {
            this._dbContext = curriculumDbContext;
            this._logger = logger;
        }
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<Curriculum> Get()
        {
            var curriculums =  _dbContext.Curriculums.ToList();
            foreach(var curriculum in curriculums)
            {
                var semesters = _dbContext.Semesters.Where(s => s.CurriculumId == curriculum.Id).ToList();
                foreach(var semester in semesters)
                {
                    semester.Courses = _dbContext.Courses.Where(cs => cs.SemesterId == semester.Id).ToList();
                }
                curriculum.Semesters = semesters;
            }
            
            return curriculums;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Curriculum Get(int id)
        {           
            var curriculum =  _dbContext.Curriculums.FirstOrDefault(c => c.Id == id);
            var semesters = _dbContext.Semesters.Where(s => s.CurriculumId == id).ToList();
            foreach(var semester in semesters)
            {
                semester.Courses = _dbContext.Courses.Where(cs => cs.SemesterId == semester.Id).ToList();
            }
            curriculum.Semesters = semesters;
            return curriculum;
        }

        //  // POST api/values
        //  [HttpPost]
        //  public void Post([FromBody]string value)
        //  {
        //  }

        //  // PUT api/values/5
        //  [HttpPut("{id}")]
        //  public void Put(int id, [FromBody]string value)
        //  {
        //  }

        //  // DELETE api/values/5
        //  [HttpDelete("{id}")]
        //  public void Delete(int id)
        //  {
        //  }
    }
}
