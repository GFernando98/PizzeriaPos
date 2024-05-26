using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.Command;
using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.Domain;
using Project.Pos.Pizzeria.WebApi.Query;
using Project.Pos.Pizzeria.WebApi.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

var sqlServerConnectionString =
    builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddTransient<IRepository<SqlServerRepository>>(x => new SqlServerRepository(sqlServerConnectionString!));

builder.Services.AddTransient<StatusDomainMessage>();
builder.Services.AddTransient<UsuariosCommand>();
builder.Services.AddTransient<UsuariosDomain>();
builder.Services.AddTransient<UsuariosRepository>();

builder.Services.AddTransient<ClientesQuery>();
builder.Services.AddTransient<ClientesRepository>();
builder.Services.AddTransient<ClientesDomain>();
builder.Services.AddTransient<ClientesCommand>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
