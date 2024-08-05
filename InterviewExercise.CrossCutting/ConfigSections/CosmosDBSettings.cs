using InterviewExercise.CrossCutting.Interfaces;

namespace InterviewExercise.CrossCutting.ConfigSections
{
    public class CosmosDBSettings : ICosmosDBSettings
    {
        public string EndpointUri { get; set; }
        public string PrimaryKey { get; set; }
        public string ConnectionString => $"AccountEndpoint={EndpointUri};AccountKey={PrimaryKey}";
        public string DatabaseName => "InterviewExerciseDb";
    }

    public class CosmosDBSettingsFactory : SettingsFactoryBase
    {
        public static ICosmosDBSettings Create() => Load(new CosmosDBSettings());
    }
}
