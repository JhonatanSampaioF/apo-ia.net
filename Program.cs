using apo_ia.net.Application.Interfaces;
using apo_ia.net.Application.Services;
using apo_ia.net.Domain.Interfaces;
using apo_ia.net.Infraestructure.Data.AppData;
using apo_ia.net.Infraestructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => {

    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));

});

builder.Services.AddTransient<IAbrigadoRepository, AbrigadoRepository>();
builder.Services.AddTransient<IAbrigadoApplicationService, AbrigadoApplicationService>();

builder.Services.AddTransient<IDoencaRepository, DoencaRepository>();
builder.Services.AddTransient<IDoencaApplicationService, DoencaApplicationService>();

builder.Services.AddTransient<IGrupoHabilidadeRepository, GrupoHabilidadeRepository>();
builder.Services.AddTransient<IGrupoHabilidadeApplicationService, GrupoHabilidadeApplicationService>();

builder.Services.AddTransient<IHabilidadeRepository, HabilidadeRepository>();
builder.Services.AddTransient<IHabilidadeApplicationService, HabilidadeApplicationService>();

builder.Services.AddTransient<ILocalRepository, LocalRepository>();
builder.Services.AddTransient<ILocalApplicationService, LocalApplicationService>();

builder.Services.AddTransient<IVoluntarioRepository, VoluntarioRepository>();
builder.Services.AddTransient<IVoluntarioApplicationService, VoluntarioApplicationService>();

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

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
