using DepartmentDataModels.Enums;

namespace DepartmentOneCMockApi.Models
{
    public class AcademicPlanRecordMockModel
    {
        public int Id { get; set; }

        public int AcademicPlanId { get; set; }

        public string Index { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int Semester { get; set; }

        public int Zet { get; set; }

        public int AcademicHours { get; set; }

        public int? Exam { get; set; }

        public int? Pass { get; set; }

        public int? GradedPass { get; set; }

        public int? CourseWork { get; set; }

        public int? CourseProject { get; set; }

        public int? Rgr { get; set; }

        public int? Lectures { get; set; }

        public int? LaboratoryHours { get; set; }

        public int? PracticalHours { get; set; }
    }
}