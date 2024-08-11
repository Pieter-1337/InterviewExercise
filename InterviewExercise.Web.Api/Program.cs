using InterviewExercise.Commands;
using InterviewExercise.CrossCutting.ConfigSections;
using InterviewExercise.CrossCutting.Interfaces;
using InterviewExercise.Data;
using InterviewExercise.Dtos;
using InterviewExercise.Handling;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

ConfigureSettings(builder.Services);
ConfigureServices(builder.Services);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    //Convert ContactType enum to string values instead of ints so that the consumer of the api has a clear indication of what the enum entries mean
    opt.MapType<ContactType>(() => new OpenApiSchema
    {
        Type = "string",
        Enum = Enum.GetNames(typeof(ContactType)).Select(name => new OpenApiString(name)).ToArray()
    });
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
// Ensure Cosmos DB containers are present at startup of app
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<UnitOfWork>();
    await context.EnsureCreatedAsync();
    
}
app.Run();


void ConfigureSettings(IServiceCollection services)
{
    builder.Services.AddSingleton(sp => CosmosDBSettingsFactory.Create());
}

void ConfigureServices(IServiceCollection services)
{
    //services.AddDbContextFactory<UnitOfWork>((sp,optionsBuilder) => {
    //    var settings = sp.GetRequiredService<ICosmosDBSettings>();
    //    optionsBuilder.UseCosmos(
    //        connectionString: settings.ConnectionString,
    //        databaseName: settings.DatabaseName
    //    );
    //});
    services.AddDbContext<UnitOfWork>((sp, options) =>
    {
        var settings = sp.GetRequiredService<ICosmosDBSettings>();
        options.UseCosmos(
            connectionString: settings.ConnectionString,
            databaseName: settings.DatabaseName
        );
    });
    //Register services related to Mediatr, tucked away in it's own class libs (Seperation of concerns...)
    services.AddHandling();
    services.AddCommands();
}