using BackGroudJob_Demo2;
using BackGroudJob_Demo2.Data;
using BackGroudJob_Demo2.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<SSHConfiguration>();
builder.Services.AddSingleton<SSH_Net>();
builder.Services.Configure<SendMailSettings>(builder.Configuration.GetSection("SendMail"));

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .Enrich.WithProcessId()
    .Enrich.WithThreadId()
    .CreateLogger();

builder.Services.AddDbContext<Dbcontext_User>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbcontextUser");
    options.UseSqlServer(connectionString);
});

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
