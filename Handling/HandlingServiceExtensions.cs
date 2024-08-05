using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace InterviewExercise.Handling
{
    public static class HandlingServiceExtensions
    {
        public static IServiceCollection AddHandling(this IServiceCollection services)
        {
            //Get all the queries, command and handlers from this class lib and register them within mediatr
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
