using Mapster;
using Microsoft.EntityFrameworkCore;
using Unguessable.Domain.Repositories;
using Unguessable.Infrastructure.Data;
using Unguessable.Infrastructure.Repositories;
using Unguessable.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Setup mapster
TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IWordRepository, WordRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IWordService, WordService>();

builder.Services.AddDbContext<UnguessableData>(options =>
{
	options.UseMySql(
				builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("5.7.37-mysql"),
				builder =>
				{
					builder.EnableRetryOnFailure(5);
				});
	options.EnableDetailedErrors();
	//options.UseSqlite("Data Source=TEST.db");
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
app.UseCors(x => x
				   .AllowAnyMethod()
				   .AllowAnyHeader()
				   .SetIsOriginAllowed(origin => true) // allow any origin
													   //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
				   .AllowCredentials()); // allow credentials

app.Run();
