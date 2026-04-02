using DepartmentDataModels.Enums;
using DepartmentOneCMockApi.Models;

namespace DepartmentOneCMockApi.Data
{
    public static class OneCTestData
    {
        public static List<AcademicPlanMockModel> AcademicPlans => new()
        {
            new AcademicPlanMockModel
            {
                Id = 1,
                EducationDirectionId = 1,
                AcademicCourses = AcademicCourse.Course_1,
                Year = 2024,
                AcademicPlanRecords = new List<AcademicPlanRecordMockModel>
                {
                    new AcademicPlanRecordMockModel
                    {
                        Id = 1,
                        AcademicPlanId = 1,
                        DisciplineId = 1,
                        AcademicPlanRecordParentId = null,
                        InDepartment = true,
                        Semester = Semesters.Первый,
                        Zet = 3,
                        IsParent = false,
                        IsChild = false,
                        IsFacultative = false,
                        IsUseInWorkload = true,
                        IsActiveSemester = true,
                        DisciplineBlockId = 1,
                        DisciplineName = "Программирование",
                        DisciplineShortName = "Программирование",
                        DisciplineDescription = "Основы программирования",
                        DisciplineBlockBlueAsteriskName = ""
                    },
                    new AcademicPlanRecordMockModel
                    {
                        Id = 2,
                        AcademicPlanId = 1,
                        DisciplineId = 2,
                        AcademicPlanRecordParentId = null,
                        InDepartment = true,
                        Semester = Semesters.Второй,
                        Zet = 4,
                        IsParent = false,
                        IsChild = false,
                        IsFacultative = false,
                        IsUseInWorkload = true,
                        IsActiveSemester = true,
                        DisciplineBlockId = 1,
                        DisciplineName = "Базы данных",
                        DisciplineShortName = "Базы данных",
                        DisciplineDescription = "Технологии работы с БД",
                        DisciplineBlockBlueAsteriskName = ""
                    }
                }
            }
        };

        public static List<StudentGroupMockModel> StudentGroups => new()
        {
            new StudentGroupMockModel
            {
                Id = 1,
                EducationDirectionId = 1,
                CuratorId = 1,
                GroupName = "ПИбд-31",
                Course = AcademicCourse.Course_3
            },
            new StudentGroupMockModel
            {
                Id = 2,
                EducationDirectionId = 1,
                CuratorId = 1,
                GroupName = "ПИбд-21",
                Course = AcademicCourse.Course_2
            }
        };

        public static List<StudentMockModel> Students => new()
        {
            new StudentMockModel
            {
                Id = 1,
                StudentGroupId = 1,
                NumberOfBook = "10001",
                FirstName = "Иван",
                LastName = "Иванов",
                Patronymic = "Иванович",
                Email = "ivanov@test.local",
                StudentState = StudentState.Учится,
                Description = "Тестовый студент",
                IsSteward = true
            },
            new StudentMockModel
            {
                Id = 2,
                StudentGroupId = 1,
                NumberOfBook = "10002",
                FirstName = "Петр",
                LastName = "Петров",
                Patronymic = "Петрович",
                Email = "petrov@test.local",
                StudentState = StudentState.Учится,
                Description = "Тестовый студент",
                IsSteward = false
            }
        };

        public static List<DisciplineStudentRecordMockModel> DisciplineStudentRecords => new()
        {
            new DisciplineStudentRecordMockModel
            {
                Id = 1,
                DisciplineId = 1,
                StudentId = 1,
                Semester = Semesters.Первый,
                Variant = "Экзамен",
                SubGroup = 1
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 2,
                DisciplineId = 2,
                StudentId = 2,
                Semester = Semesters.Второй,
                Variant = "Зачет",
                SubGroup = 1
            }
        };
    }
}