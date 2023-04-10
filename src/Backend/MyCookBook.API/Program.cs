using MyCookBook.Infrastructure.Migrations;
using MyCookBook.Domain.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.MapControllers();

UpdateDataBase();

app.Run();

void UpdateDataBase()
{
	var databaseName = builder.Configuration.GetDatabaseName();
	var connection = builder.Configuration.GetDatabaseConnection();

	Database.CreateDataBase(connection,databaseName);
}