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
    public class Classroom : IClassroomModel
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        [Required]
        public string Number { get; private set; } = string.Empty;

        [DataMember]
        [Required]
        public ClassroomTypes ClassroomType { get; private set; }

        [DataMember]
        [Required]
        public int Capacity { get; private set; }

        [DataMember]
        [Required]
        public bool NotUseInSchedule { get; private set; }

        public static Classroom? Create(ClassroomBindingModel model)
        {
            if (model == null) return null;
            return new()
            {
                Id = model.Id,
                Number = model.Number,
                ClassroomType = model.ClassroomType,
                Capacity = model.Capacity,
                NotUseInSchedule = model.NotUseInSchedule,
            };
        }

        public void Update(ClassroomBindingModel model)
        {
            if (model == null) return;
            Number = model.Number;
            ClassroomType = model.ClassroomType;
            Capacity = model.Capacity;
            NotUseInSchedule = model.NotUseInSchedule;
        }

        public ClassroomViewModel GetViewModel => new()
        {
            Id = Id,
            Number = Number,
            ClassroomType = ClassroomType,
            Capacity = Capacity,
            NotUseInSchedule = NotUseInSchedule,
        };
    }
}
