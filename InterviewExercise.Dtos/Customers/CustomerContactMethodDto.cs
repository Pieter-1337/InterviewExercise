using System.Text.Json.Serialization;

namespace InterviewExercise.Dtos.Customers
{
    public class CustomerContactMethodDto
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContactType Type { get; set; }
        public string Value { get; set; }
        public string TypeAsString => Type.ToString();
    }
}
