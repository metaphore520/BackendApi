using BackendApi;
using BackendApi.Contracts;
using BackendApi.DbContextFile;
using BackendApi.Repository;
using BackendApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.PropertyNamingPolicy = null);



builder.Services.AddDbContext<AssesmentDbContext>();

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<IMarkRepository, MarkRepository>();


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();



builder.Services.AddTransient<IMarkService, MarkService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<ICourseService, CourseService>();
builder.Services.AddTransient<IServiceWrapper, Services>();








var app = builder.Build();





// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
