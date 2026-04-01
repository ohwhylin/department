using DepartmentDataModels.Enums;

namespace DepartmentOneCMockApi.Models
{
    public class AcademicPlanRecordMockModel
    {
        public int Id { get; set; }

        public int AcademicPlanId { get; set; }

        public int DisciplineId { get; set; }

        public int? AcademicPlanRecordParentId { get; set; }

        public bool InDepartment { get; set; }

        public Semesters Semester { get; set; }

        public int Zet { get; set; }

        public bool IsParent { get; set; }

        public bool IsChild { get; set; }

        public bool IsFacultative { get; set; }

        public bool IsUseInWorkload { get; set; }

        public bool IsActiveSemester { get; set; }

        public int DisciplineBlockId { get; set; }

        public string DisciplineName { get; set; } = string.Empty;

        public string DisciplineShortName { get; set; } = string.Empty;

        public string DisciplineDescription { get; set; } = string.Empty;

        public string DisciplineBlockBlueAsteriskName { get; set; } = string.Empty;
    }
}
