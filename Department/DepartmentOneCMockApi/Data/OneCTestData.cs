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
                Year = "2030-2031",
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
                Year = "2024-2025",
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
                Year = "2025-2026",
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
                Year = "2025-2026",
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
                GroupName = "ПИбд-41",
                Course = AcademicCourse.Course_4
            },
            new StudentGroupMockModel
            {
                Id = 2,
                EducationDirectionId = 1,
                CuratorId = 2,
                GroupName = "ПИбд-31",
                Course = AcademicCourse.Course_3
            },
            new StudentGroupMockModel
            {
                Id = 3,
                EducationDirectionId = 1,
                CuratorId = 2,
                GroupName = "ПИбд-21",
                Course = AcademicCourse.Course_2
            }
        };

        public static List<StudentMockModel> Students => new()
        {
            // Группа ПИбд-41 (5 студентов)
            new StudentMockModel
            {
                Id = 1,
                StudentGroupId = 1,
                NumberOfBook = "10001",
                FirstName = "Александр",
                LastName = "Кузнецов",
                Patronymic = "Андреевич",
                Email = "a.kuznetsov@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = true
            },
            new StudentMockModel
            {
                Id = 2,
                StudentGroupId = 1,
                NumberOfBook = "10002",
                FirstName = "Екатерина",
                LastName = "Смирнова",
                Patronymic = "Дмитриевна",
                Email = "e.smirnova@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = false
            },
            new StudentMockModel
            {
                Id = 3,
                StudentGroupId = 1,
                NumberOfBook = "10003",
                FirstName = "Дмитрий",
                LastName = "Волков",
                Patronymic = "Сергеевич",
                Email = "d.volkov@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = false
            },
            new StudentMockModel
            {
                Id = 4,
                StudentGroupId = 1,
                NumberOfBook = "10004",
                FirstName = "Анна",
                LastName = "Морозова",
                Patronymic = "Игоревна",
                Email = "a.morozova@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = false
            },
            new StudentMockModel
            {
                Id = 5,
                StudentGroupId = 1,
                NumberOfBook = "10005",
                FirstName = "Максим",
                LastName = "Новиков",
                Patronymic = "Владимирович",
                Email = "m.novikov@university.ru",
                StudentState = StudentState.Академ,
                Description = "",
                IsSteward = false
            },

            // Группа ПИбд-31 (5 студентов)
            new StudentMockModel
            {
                Id = 6,
                StudentGroupId = 2,
                NumberOfBook = "10006",
                FirstName = "Ольга",
                LastName = "Федорова",
                Patronymic = "Алексеевна",
                Email = "o.fedorova@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = true
            },
            new StudentMockModel
            {
                Id = 7,
                StudentGroupId = 2,
                NumberOfBook = "10007",
                FirstName = "Сергей",
                LastName = "Михайлов",
                Patronymic = "Петрович",
                Email = "s.mikhailov@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = false
            },
            new StudentMockModel
            {
                Id = 8,
                StudentGroupId = 2,
                NumberOfBook = "10008",
                FirstName = "Татьяна",
                LastName = "Егорова",
                Patronymic = "Николаевна",
                Email = "t.egorova@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = false
            },
            new StudentMockModel
            {
                Id = 9,
                StudentGroupId = 2,
                NumberOfBook = "10009",
                FirstName = "Андрей",
                LastName = "Козлов",
                Patronymic = "Валерьевич",
                Email = "a.kozlov@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = false
            },
            new StudentMockModel
            {
                Id = 10,
                StudentGroupId = 2,
                NumberOfBook = "10010",
                FirstName = "Юлия",
                LastName = "Соколова",
                Patronymic = "Викторовна",
                Email = "y.sokolova@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = false
            },

            // Группа ПИбд-21 (4 студента)
            new StudentMockModel
            {
                Id = 11,
                StudentGroupId = 3,
                NumberOfBook = "10011",
                FirstName = "Никита",
                LastName = "Лебедев",
                Patronymic = "Александрович",
                Email = "n.lebedev@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = true
            },
            new StudentMockModel
            {
                Id = 12,
                StudentGroupId = 3,
                NumberOfBook = "10012",
                FirstName = "Мария",
                LastName = "Павлова",
                Patronymic = "Андреевна",
                Email = "m.pavlova@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = false
            },
            new StudentMockModel
            {
                Id = 13,
                StudentGroupId = 3,
                NumberOfBook = "10013",
                FirstName = "Артем",
                LastName = "Семенов",
                Patronymic = "Иванович",
                Email = "a.semenov@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
                IsSteward = false
            },
            new StudentMockModel
            {
                Id = 14,
                StudentGroupId = 3,
                NumberOfBook = "10014",
                FirstName = "Елена",
                LastName = "Тихонова",
                Patronymic = "Сергеевна",
                Email = "e.tikhonova@university.ru",
                StudentState = StudentState.Учится,
                Description = "",
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
                SubGroup = 1,
                MarkType = MarkType.Отлично
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 2,
                DisciplineId = 2,
                StudentId = 2,
                Semester = Semesters.Второй,
                Variant = "Зачет",
                SubGroup = 1,
                MarkType = MarkType.Хорошо
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 3,
                DisciplineId = 3,
                StudentId = 3,
                Semester = Semesters.Первый,
                Variant = "Экзамен",
                SubGroup = 2,
                MarkType = MarkType.Удовлетворительно
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 4,
                DisciplineId = 4,
                StudentId = 4,
                Semester = Semesters.Второй,
                Variant = "Зачет",
                SubGroup = 2,
                MarkType = MarkType.Отлично
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 5,
                DisciplineId = 5,
                StudentId = 5,
                Semester = Semesters.Первый,
                Variant = "Экзамен",
                SubGroup = 3,
                MarkType = MarkType.Неявка
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 6,
                DisciplineId = 6,
                StudentId = 6,
                Semester = Semesters.Второй,
                Variant = "Зачет",
                SubGroup = 3,
                MarkType = MarkType.Хорошо
            },

            new DisciplineStudentRecordMockModel
            {
                Id = 7,
                DisciplineId = 7,
                StudentId = 7,
                Semester = Semesters.Первый,
                Variant = "Экзамен",
                SubGroup = 1,
                MarkType = MarkType.Неудовлетворительно
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 8,
                DisciplineId = 8,
                StudentId = 8,
                Semester = Semesters.Второй,
                Variant = "Экзамен",
                SubGroup = 1,
                MarkType = MarkType.Хорошо
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 9,
                DisciplineId = 9,
                StudentId = 9,
                Semester = Semesters.Первый,
                Variant = "Экзамен",
                SubGroup = 2,
                MarkType = MarkType.Отлично
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 10,
                DisciplineId = 10,
                StudentId = 10,
                Semester = Semesters.Второй,
                Variant = "Зачет",
                SubGroup = 2,
                MarkType = MarkType.Удовлетворительно
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 11,
                DisciplineId = 11,
                StudentId = 11,
                Semester = Semesters.Второй,
                Variant = "Зачет",
                SubGroup = 1,
                MarkType = MarkType.Хорошо
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 12,
                DisciplineId = 4,
                StudentId = 12,
                Semester = Semesters.Первый,
                Variant = "Экзамен",
                SubGroup = 1,
                MarkType = MarkType.Отлично
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 13,
                DisciplineId = 5,
                StudentId = 13,
                Semester = Semesters.Второй,
                Variant = "Экзамен",
                SubGroup = 2,
                MarkType = MarkType.Неудовлетворительно
            },
            new DisciplineStudentRecordMockModel
            {
                Id = 14,
                DisciplineId = 6,
                StudentId = 14,
                Semester = Semesters.Первый,
                Variant = "Зачет",
                SubGroup = 2,
                MarkType = MarkType.Неявка
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
                            },
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 2,
                                StudentOrderBlockId = 1,
                                StudentId = 2,
                                StudentGroupFromId = 1,
                                StudentGroupToId = 2
                            }
                        }
                    },
                    new StudentOrderBlockMockModel
                    {
                        Id = 2,
                        StudentOrderId = 1,
                        EducationDirectionId = 1,
                        StudentOrderType = StudentOrderType.ПереводВГруппу,
                        Students = new List<StudentOrderBlockStudentMockModel>
                        {
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 3,
                                StudentOrderBlockId = 2,
                                StudentId = 6,
                                StudentGroupFromId = 2,
                                StudentGroupToId = 1
                            }
                        }
                    }
                }
            },

            new StudentOrderMockModel
            {
                Id = 2,
                OrderNumber = "124",
                StudentOrderType = StudentOrderType.ПереводВГруппу,
                Blocks = new List<StudentOrderBlockMockModel>
                {
                    new StudentOrderBlockMockModel
                    {
                        Id = 3,
                        StudentOrderId = 2,
                        EducationDirectionId = 1,
                        StudentOrderType = StudentOrderType.ПереводВГруппу,
                        Students = new List<StudentOrderBlockStudentMockModel>
                        {
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 4,
                                StudentOrderBlockId = 3,
                                StudentId = 7,
                                StudentGroupFromId = 2,
                                StudentGroupToId = 3
                            },
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 5,
                                StudentOrderBlockId = 3,
                                StudentId = 8,
                                StudentGroupFromId = 2,
                                StudentGroupToId = 3
                            }
                        }
                    }
                }
            },

            new StudentOrderMockModel
            {
                Id = 3,
                OrderNumber = "125",
                StudentOrderType = StudentOrderType.ПереводВГруппу,
                Blocks = new List<StudentOrderBlockMockModel>
                {
                    new StudentOrderBlockMockModel
                    {
                        Id = 4,
                        StudentOrderId = 3,
                        EducationDirectionId = 1,
                        StudentOrderType = StudentOrderType.ПереводВГруппу,
                        Students = new List<StudentOrderBlockStudentMockModel>
                        {
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 6,
                                StudentOrderBlockId = 4,
                                StudentId = 11,
                                StudentGroupFromId = 3,
                                StudentGroupToId = 1
                            }
                        }
                    },
                    new StudentOrderBlockMockModel
                    {
                        Id = 5,
                        StudentOrderId = 3,
                        EducationDirectionId = 1,
                        StudentOrderType = StudentOrderType.ПереводВГруппу,
                        Students = new List<StudentOrderBlockStudentMockModel>
                        {
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 7,
                                StudentOrderBlockId = 5,
                                StudentId = 12,
                                StudentGroupFromId = 3,
                                StudentGroupToId = 2
                            },
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 8,
                                StudentOrderBlockId = 5,
                                StudentId = 13,
                                StudentGroupFromId = 3,
                                StudentGroupToId = 2
                            },
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 9,
                                StudentOrderBlockId = 5,
                                StudentId = 14,
                                StudentGroupFromId = 3,
                                StudentGroupToId = 2
                            }
                        }
                    }
                }
            },

            new StudentOrderMockModel
            {
                Id = 4,
                OrderNumber = "126",
                StudentOrderType = StudentOrderType.ПереводВГруппу,
                Blocks = new List<StudentOrderBlockMockModel>
                {
                    new StudentOrderBlockMockModel
                    {
                        Id = 6,
                        StudentOrderId = 4,
                        EducationDirectionId = 1,
                        StudentOrderType = StudentOrderType.ПереводВГруппу,
                        Students = new List<StudentOrderBlockStudentMockModel>
                        {
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 10,
                                StudentOrderBlockId = 6,
                                StudentId = 3,
                                StudentGroupFromId = 1,
                                StudentGroupToId = 3
                            },
                            new StudentOrderBlockStudentMockModel
                            {
                                Id = 11,
                                StudentOrderBlockId = 6,
                                StudentId = 4,
                                StudentGroupFromId = 1,
                                StudentGroupToId = 3
                            }
                        }
                    }
                }
            }
        };
    }
}