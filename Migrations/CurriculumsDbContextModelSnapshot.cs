using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using FiDeLo3.Resources.Curriculums.Models;

namespace FiDeLo3.Resources.Curriculums.Migrations
{
    [DbContext(typeof(CurriculumsDbContext))]
    partial class CurriculumsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964");

            modelBuilder.Entity("FiDeLo3.Resources.Curriculums.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<uint>("ClassesHours");

                    b.Property<int>("CourseProvider");

                    b.Property<ushort>("EctsPoints");

                    b.Property<bool>("HasExam");

                    b.Property<bool>("IsForeignLanguage");

                    b.Property<bool>("IsSportType");

                    b.Property<uint>("LaboratoriesHours");

                    b.Property<uint>("LectureHours");

                    b.Property<string>("Name");

                    b.Property<uint>("ProjectHours");

                    b.Property<int>("SemesterId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FiDeLo3.Resources.Curriculums.Models.Curriculum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<uint>("CycleOfStudies");

                    b.Property<bool>("IsFullTime");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FiDeLo3.Resources.Curriculums.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurriculumId");

                    b.Property<uint>("OrderNumber");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("FiDeLo3.Resources.Curriculums.Models.Course", b =>
                {
                    b.HasOne("FiDeLo3.Resources.Curriculums.Models.Semester")
                        .WithMany()
                        .ForeignKey("SemesterId");
                });

            modelBuilder.Entity("FiDeLo3.Resources.Curriculums.Models.Semester", b =>
                {
                    b.HasOne("FiDeLo3.Resources.Curriculums.Models.Curriculum")
                        .WithMany()
                        .ForeignKey("CurriculumId");
                });
        }
    }
}
