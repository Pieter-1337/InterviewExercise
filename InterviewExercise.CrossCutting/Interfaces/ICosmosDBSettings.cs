
namespace InterviewExercise.CrossCutting.Interfaces
{
    public interface ICosmosDBSettings
    {
        string EndpointUri { get; set; }
        string PrimaryKey { get; set; }
        string ConnectionString { get; }
        string DatabaseName { get; }
    }
}
