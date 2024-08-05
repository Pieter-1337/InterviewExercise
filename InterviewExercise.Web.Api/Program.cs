using InterviewExercise.CrossCutting.ConfigSections;
using InterviewExercise.CrossCutting.Interfaces;
using InterviewExercise.Data;
using InterviewExercise.Handling;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureSettings(builder.Services);
ConfigureServices(builder.Services);
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
// Ensure Cosmos DB containers are created
using (var scope = app.Services.CreateScope())
{
    var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<UnitOfWork>>();
    using (var context = contextFactory.CreateDbContext())
    {
        await context.EnsureCreatedAsync();
    }
}
app.Run();


void ConfigureSettings(IServiceCollection services)
{
    builder.Services.AddSingleton(sp => CosmosDBSettingsFactory.Create());
}

void ConfigureServices(IServiceCollection services)
{
    services.AddDbContextFactory<UnitOfWork>((sp,optionsBuilder) => {
        var settings = sp.GetRequiredService<ICosmosDBSettings>();
        optionsBuilder.UseCosmos(
            connectionString: settings.ConnectionString,
            databaseName: settings.DatabaseName
        );
    });
    //Register handling services related to Mediatr, tucked away in it's own class lib for decoupling
    services.AddHandling();
}