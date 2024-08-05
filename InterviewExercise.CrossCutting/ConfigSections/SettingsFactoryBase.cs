using Microsoft.Extensions.Configuration;

namespace InterviewExercise.CrossCutting.ConfigSections
{
    public abstract class SettingsFactoryBase
    {
        /// <summary>
        /// Load configuration settings for specified configuration class.
        /// Note: The config file element name should be the same as the configuration class name.
        /// </summary>
        /// <param name="configuration">Configuration instance to load from jsonconfig files</param>
        /// <returns>Original passed instance filled with values from config files</returns>
        protected static T Load<T>(T configuration)
        {
            var configurationRoot = GetIConfigurationRoot();

            configurationRoot
                .GetSection(configuration.GetType().Name)
                .Bind(configuration);

            return configuration;
        }

        public static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder()//mind the order!
                                             //Default config file for default values
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)

                //Basic config file for local development
                //make sure the Development config file is never copied to the publish directory
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)

                //Placeholder config file for publish on external environment
                //make sure the Production config file is never copied to output directory (local development)
                .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true)

                //Specific config file for local development for one developer
                .AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true)

                .Build();
        }
    }
}