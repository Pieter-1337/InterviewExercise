using InterviewExercise.Dtos;

namespace InterviewExercise.Domain.Entities
{
    public class CustomerContactMethod : EntityBase
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ContactType Type { get; set; }
        public string Value { get; set; }
    }
}
