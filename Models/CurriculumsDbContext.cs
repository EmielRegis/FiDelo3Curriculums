using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace FiDeLo3.Resources.Curriculums.Models
{
	public class CurriculumsDbContext : DbContext
	{
		public DbSet<Curriculum> Curriculums { get; set; }
		public DbSet<Semester> Semesters { get; set; }

		public DbSet<Course> Courses { get; set; }
		
		
		public CurriculumsDbContext (DbContextOptions options)
        : base(options)
    	{ }
		
		
		protected override void OnModelCreating(ModelBuilder builder)
        {
			
            base.OnModelCreating(builder);

			//  Curriculums.Add(new Curriculum{ Name = "Some Curriculum" });

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
	}
}