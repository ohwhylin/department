using DepartmentBusinessLogic.BusinessLogics;
using DepartmentContracts.BusinessLogicsContracts;
using DepartmentContracts.StoragesContracts;
using DepartmentDatabaseImplement.Implements;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Logging.AddLog4Net("log4net.config");

// Add services to the container.
builder.Services.AddTransient<IAcademicPlanStorage, AcademicPlanStorage>();
builder.Services.AddTransient<IAcademicPlanRecordStorage, AcademicPlanRecordStorage>();
builder.Services.AddTransient<IClassroomStorage, ClassroomStorage>();
builder.Services.AddTransient<IDisciplineStorage, DisciplineStorage>();
builder.Services.AddTransient<IDisciplineBlockStorage, DisciplineBlockStorage>();
builder.Services.AddTransient<IDisciplineStudentRecordStorage, DisciplineStudentRecordStorage>();
builder.Services.AddTransient<IEducationDirectionStorage, EducationDirectionStorage>();
builder.Services.AddTransient<ILecturerStorage, LecturerStorage>();
builder.Services.AddTransient<ILecturerStudyPostStorage, LecturerStudyPostStorage>();
builder.Services.AddTransient<ILecturerDepartmentPostStorage, LecturerDepartmentPostStorage>();
builder.Services.AddTransient<IStudentStorage, StudentStorage>();
builder.Services.AddTransient<IStudentGroupStorage, StudentGroupStorage>();
builder.Services.AddTransient<IStudentOrderStorage, StudentOrderStorage>();
builder.Services.AddTransient<IStudentOrderBlockStorage, StudentOrderBlockStorage>();
builder.Services.AddTransient<IStudentOrderBlockStudentStorage, StudentOrderBlockStudentStorage>();

builder.Services.AddTransient<IAcademicPlanLogic, AcademicPlanLogic>();
builder.Services.AddTransient<IAcademicPlanRecordLogic, AcademicPlanRecordLogic>();
builder.Services.AddTransient<IClassroomLogic, ClassroomLogic>();
builder.Services.AddTransient<IDisciplineLogic, DisciplineLogic>();
builder.Services.AddTransient<IDisciplineBlockLogic, DisciplineBlockLogic>();
builder.Services.AddTransient<IDisciplineStudentRecordLogic, DisciplineStudentRecordLogic>();
builder.Services.AddTransient<IEducationDirectionLogic, EducationDirectionLogic>();
builder.Services.AddTransient<ILecturerLogic, LecturerLogic>();
builder.Services.AddTransient<ILecturerStudyPostLogic, LecturerStudyPostLogic>();
builder.Services.AddTransient<ILecturerDepartmentPostLogic, LecturerDepartmentPostLogic>();
builder.Services.AddTransient<IStudentLogic, StudentLogic>();
builder.Services.AddTransient<IStudentGroupLogic, StudentGroupLogic>();
builder.Services.AddTransient<IStudentOrderLogic, StudentOrderLogic>();
builder.Services.AddTransient<IStudentOrderBlockLogic, StudentOrderBlockLogic>();
builder.Services.AddTransient<IStudentOrderBlockStudentLogic, StudentOrderBlockStudentLogic>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DepartmentRestApi", Version = "v1"});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DepartmentRestApi"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
