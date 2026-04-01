using DepartmentDataModels.Enums;

namespace DepartmentOneCMockApi.Models
{
    public class AcademicPlanMockModel
    {
        public int Id { get; set; }

        public int? EducationDirectionId { get; set; }

        public AcademicCourse AcademicCourses { get; set; }

        public int Year { get; set; }

        public List<AcademicPlanRecordMockModel> AcademicPlanRecords { get; set; } = new();
    }
}