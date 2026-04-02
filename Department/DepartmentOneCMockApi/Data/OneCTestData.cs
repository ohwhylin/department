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
                    },
                    new AcademicPlanRecordMockModel
                    {
                        Id = 3,
                        AcademicPlanId = 1,
                        DisciplineId = 3,
                        AcademicPlanRecordParentId = null,
                        InDepartment = true,
                        Semester = Semesters.Второй,
                        Zet = 2,
                        IsParent = false,
                        IsChild = false,
                        IsFacultative = false,
                        IsUseInWorkload = true,
                        IsActiveSemester = true,
                        DisciplineBlockId = 1,
                        DisciplineName = "Математический анализ",
                        DisciplineShortName = "Матан",
                        DisciplineDescription = "Базовый курс математического анализа",
                        DisciplineBlockBlueAsteriskName = ""
                    }
                }
            },

            new AcademicPlanMockModel
            {
                Id = 2,
                EducationDirectionId = 1,
                AcademicCourses = AcademicCourse.Course_2,
                Year = 2024,
                AcademicPlanRecords = new List<AcademicPlanRecordMockModel>
                {
                    new AcademicPlanRecordMockModel
                    {
                        Id = 4,
                        AcademicPlanId = 2,
                        DisciplineId = 4,
                        AcademicPlanRecordParentId = null,
                        InDepartment = true,
                        Semester = Semesters.Первый,
                        Zet = 4,
                        IsParent = false,
                        IsChild = false,
                        IsFacultative = false,
                        IsUseInWorkload = true,
                        IsActiveSemester = true,
                        DisciplineBlockId = 1,
                        DisciplineName = "Алгоритмы и структуры данных",
                        DisciplineShortName = "Алгоритмы",
                        DisciplineDescription = "Алгоритмы, структуры данных и их анализ",
                        DisciplineBlockBlueAsteriskName = ""
                    },
                    new AcademicPlanRecordMockModel
                    {
                        Id = 5,
                        AcademicPlanId = 2,
                        DisciplineId = 5,
                        AcademicPlanRecordParentId = null,
                        InDepartment = true,
                        Semester = Semesters.Второй,
                        Zet = 3,
                        IsParent = false,
                        IsChild = false,
                        IsFacultative = false,
                        IsUseInWorkload = true,
                        IsActiveSemester = true,
                        DisciplineBlockId = 1,
                        DisciplineName = "Операционные системы",
                        DisciplineShortName = "ОС",
                        DisciplineDescription = "Основы современных операционных систем",
                        DisciplineBlockBlueAsteriskName = ""
                    }
                }
            },

            new AcademicPlanMockModel
            {
                Id = 3,
                EducationDirectionId = 1,
                AcademicCourses = AcademicCourse.Course_3,
                Year = 2025,
                AcademicPlanRecords = new List<AcademicPlanRecordMockModel>
                {
                    new AcademicPlanRecordMockModel
                    {
                        Id = 6,
                        AcademicPlanId = 3,
                        DisciplineId = 6,
                        AcademicPlanRecordParentId = null,
                        InDepartment = true,
                        Semester = Semesters.Первый,
                        Zet = 5,
                        IsParent = false,
                        IsChild = false,
                        IsFacultative = false,
                        IsUseInWorkload = true,
                        IsActiveSemester = true,
                        DisciplineBlockId = 1,
                        DisciplineName = "Сетевые технологии",
                        DisciplineShortName = "Сети",
                        DisciplineDescription = "Проектирование и администрирование компьютерных сетей",
                        DisciplineBlockBlueAsteriskName = ""
                    },
                    new AcademicPlanRecordMockModel
                    {
                        Id = 7,
                        AcademicPlanId = 3,
                        DisciplineId = 7,
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
                        DisciplineName = "Информационная безопасность",
                        DisciplineShortName = "ИБ",
                        DisciplineDescription = "Основы защиты информации",
                        DisciplineBlockBlueAsteriskName = ""
                    },
                    new AcademicPlanRecordMockModel
                    {
                        Id = 8,
                        AcademicPlanId = 3,
                        DisciplineId = 8,
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
                        DisciplineName = "Проектирование информационных систем",
                        DisciplineShortName = "Проектирование ИС",
                        DisciplineDescription = "Методы проектирования и моделирования ИС",
                        DisciplineBlockBlueAsteriskName = ""
                    }
                }
            },

            new AcademicPlanMockModel
            {
                Id = 4,
                EducationDirectionId = 1,
                AcademicCourses = AcademicCourse.Course_4,
                Year = 2025,
                AcademicPlanRecords = new List<AcademicPlanRecordMockModel>
                {
                    new AcademicPlanRecordMockModel
                    {
                        Id = 9,
                        AcademicPlanId = 4,
                        DisciplineId = 9,
                        AcademicPlanRecordParentId = null,
                        InDepartment = true,
                        Semester = Semesters.Первый,
                        Zet = 6,
                        IsParent = false,
                        IsChild = false,
                        IsFacultative = false,
                        IsUseInWorkload = true,
                        IsActiveSemester = true,
                        DisciplineBlockId = 1,
                        DisciplineName = "Машинное обучение",
                        DisciplineShortName = "ML",
                        DisciplineDescription = "Введение в машинное обучение",
                        DisciplineBlockBlueAsteriskName = ""
                    },
                    new AcademicPlanRecordMockModel
                    {
                        Id = 10,
                        AcademicPlanId = 4,
                        DisciplineId = 10,
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
                        DisciplineName = "Управление ИТ-проектами",
                        DisciplineShortName = "ИТ-проекты",
                        DisciplineDescription = "Методологии и практики управления ИТ-проектами",
                        DisciplineBlockBlueAsteriskName = ""
                    },
                    new AcademicPlanRecordMockModel
                    {
                        Id = 11,
                        AcademicPlanId = 4,
                        DisciplineId = 11,
                        AcademicPlanRecordParentId = null,
                        InDepartment = true,
                        Semester = Semesters.Второй,
                        Zet = 3,
                        IsParent = false,
                        IsChild = false,
                        IsFacultative = true,
                        IsUseInWorkload = true,
                        IsActiveSemester = true,
                        DisciplineBlockId = 1,
                        DisciplineName = "Облачные технологии",
                        DisciplineShortName = "Cloud",
                        DisciplineDescription = "Современные облачные платформы и сервисы",
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

        public static List<StudentOrderMockModel> StudentOrders => new()
        {
            new StudentOrderMockModel
            {
                Id = 1,
                OrderNumber = "123",
                StudentOrderType = StudentOrderType.ПереводВГруппу,
                Blocks = new List<StudentOrderBlockMockModel>
                {
                    new StudentOrderBlockMockModel
                    {
                        Id = 1,
                        StudentOrderId = 1,
                        EducationDirectionId = 1,
                        StudentOrderType = StudentOrderType.ПереводВГруппу,
                        Students = new List<StudentOrderBlockStudentMockModel>
                        {
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 1,
                                StudentOrderBlockId = 1,
                                StudentId = 1,
                                StudentGroupFromId = 1,
                                StudentGroupToId = 2
                            }
                        }
                    }
                }
            }
        };
    }
}