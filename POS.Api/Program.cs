<<<<<<< HEAD
using POS.Application.Extensions;
=======
>>>>>>> 6d20b31533ce8f586b93660028abbb8bd68570ec
using POS.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddInjectionInfraestructure(Configuration);
<<<<<<< HEAD
builder.Services.AddInjectionApplication(Configuration);
=======
>>>>>>> 6d20b31533ce8f586b93660028abbb8bd68570ec

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

app.Run();

public partial class Program { }