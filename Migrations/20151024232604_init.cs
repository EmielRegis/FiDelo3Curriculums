using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace FiDeLo3.Resources.Curriculums.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curriculum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CycleOfStudies = table.Column<uint>(nullable: false),
                    IsFullTime = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurriculumId = table.Column<int>(nullable: false),
                    OrderNumber = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semester_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassesHours = table.Column<uint>(nullable: false),
                    CourseProvider = table.Column<int>(nullable: false),
                    EctsPoints = table.Column<ushort>(nullable: false),
                    HasExam = table.Column<bool>(nullable: false),
                    IsForeignLanguage = table.Column<bool>(nullable: false),
                    IsSportType = table.Column<bool>(nullable: false),
                    LaboratoriesHours = table.Column<uint>(nullable: false),
                    LectureHours = table.Column<uint>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProjectHours = table.Column<uint>(nullable: false),
                    SemesterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Course");
            migrationBuilder.DropTable("Semester");
            migrationBuilder.DropTable("Curriculum");
        }
    }
}
