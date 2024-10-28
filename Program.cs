using Microsoft.EntityFrameworkCore;
using ReservationManagementSystem;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddService();
builder.Services.AddDbContext<DataContext>(x =>
    x.UseNpgsql(builder.Configuration["ConnectionString"]));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();