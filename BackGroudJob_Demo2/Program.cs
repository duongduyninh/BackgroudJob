using BackGroudJob_Demo2;
using BackGroudJob_Demo2.Data;
using Microsoft.EntityFrameworkCore;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Dbcontext_User>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbcontextUser");
    options.UseSqlServer(connectionString);
});

//builder.Services.AddHostedService<BackgroundJobService>();

builder.Services.AddQuartz(options =>
{
    var jobKey = new JobKey(nameof(BackgroudJobService_Quartz));

    options
        .AddJob<BackgroudJobService_Quartz>(jobKey)
        .AddTrigger(
            trigger => trigger.ForJob(jobKey).WithSimpleSchedule(
                schedule => schedule.WithIntervalInSeconds(15).RepeatForever()));
    options.UseMicrosoftDependencyInjectionJobFactory();
});

builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
