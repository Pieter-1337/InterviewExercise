using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace InterviewExercise.Commands
{
    public static class CommandsServiceExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services) 
        {
            //Get all commands from this class lib and register them within mediatr
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
