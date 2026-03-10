using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using DepartmentContracts.BindingModels;
using DepartmentContracts.ViewModels;
using DepartmentDataModels.Models;
using DepartmentDataModels.Enums;

namespace DepartmentDatabaseImplement.Models
{
    [DataContract]
    public class AcademicPlanRecord : IAcademicPlanRecordModel
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        [Required]
        public int AcademicPlanId { get; private set; }
        public virtual AcademicPlan AcademicPlan { get; set; } = null!;

        [DataMember]
        [Required]
        public int DisciplineId { get; private set; }
        public virtual Discipline Discipline { get; set; } = null!;

        [DataMember]
        public int? AcademicPlanRecordParentId { get; private set; }
        public virtual AcademicPlanRecord? AcademicPlanRecordParent { get; set; } = null!;

        [DataMember]
        [Required]
        public bool InDepartment { get; private set; }

        [DataMember]
        [Required]
        public Semesters Semester { get; private set; }

        [DataMember]
        [Required]
        public int Zet { get; private set; }

        [DataMember]
        [Required]
        public bool IsParent { get; private set; }

        [DataMember]
        [Required]
        public bool IsChild { get; private set; }

        [DataMember]
        [Required]
        public bool IsFacultative { get; private set; }

        [DataMember]
        [Required]
        public bool IsUseInWorkload { get; private set; }

        [DataMember]
        [Required]
        public bool IsActiveSemester { get; private set; }
        [ForeignKey("AcademicPlanRecordParentId")]
        public virtual List<AcademicPlanRecord> AcademicPlanRecords { get; set; }

        public static AcademicPlanRecord? Create(AcademicPlanRecordBindingModel model)
        {
            if (model == null) return null;
            return new()
            {
                Id = model.Id,
                AcademicPlanId = model.AcademicPlanId,
                DisciplineId = model.DisciplineId,
                AcademicPlanRecordParentId = model.AcademicPlanRecordParentId,
                InDepartment = model.InDepartment,
                Semester = model.Semester,
                Zet = model.Zet,
                IsParent = model.IsParent,
                IsChild = model.IsChild,
                IsFacultative = model.IsFacultative,
                IsUseInWorkload = model.IsUseInWorkload,
                IsActiveSemester = model.IsActiveSemester,
            };
        }

        public void Update(AcademicPlanRecordBindingModel model)
        {
            if (model == null) return;
            AcademicPlanId = model.AcademicPlanId;
            DisciplineId = model.DisciplineId;
            AcademicPlanRecordParentId = model.AcademicPlanRecordParentId;
            InDepartment = model.InDepartment;
            Semester = model.Semester;
            Zet = model.Zet;
            IsParent = model.IsParent;
            IsChild = model.IsChild;
            IsFacultative = model.IsFacultative;
            IsUseInWorkload = model.IsUseInWorkload;
            IsActiveSemester = model.IsActiveSemester;
        }

        public AcademicPlanRecordViewModel GetViewModel => new()
        {
            Id = Id,
            AcademicPlanId = AcademicPlanId,
            DisciplineId = DisciplineId,
            AcademicPlanRecordParentId = AcademicPlanRecordParentId,
            InDepartment = InDepartment,
            Semester = Semester,
            Zet = Zet,
            IsParent = IsParent,
            IsChild = IsChild,
            IsFacultative = IsFacultative,
            IsUseInWorkload = IsUseInWorkload,
            IsActiveSemester = IsActiveSemester,
        };
    }
}
