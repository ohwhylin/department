using DepartmentDataModels.Enums;

namespace DepartmentContracts.Dtos.OneC
{
    public class AcademicPlanOneCDto
    {
        public int Id { get; set; }

        public int? EducationDirectionId { get; set; }

        public AcademicCourse AcademicCourses { get; set; }

        public int Year { get; set; }
    }
}