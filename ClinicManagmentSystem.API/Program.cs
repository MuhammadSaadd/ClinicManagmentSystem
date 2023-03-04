using Hangfire;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.RegisterBusinessServices();

builder.Services.RegisterDataServices(builder.Configuration);

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard("/dashboard");

app.MapControllers();

app.Run();


// 6ab2b120-30a4-4258-a2bc-08db1a5cf055 | 3fa85f64-5717-4562-b3fc-2c963f66afa6 => clinics
// 812399fb-e9e7-4834-f9f3-08db1caf1fac | c2eba0b6-1460-4985-121e-08db1cb39da6 => phys
