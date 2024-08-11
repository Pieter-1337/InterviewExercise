using System.Collections.ObjectModel;

namespace InterviewExercise.Dtos.Customers
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<CustomerContactMethodDto> CustomerContactMethods { get; set; } = new Collection<CustomerContactMethodDto>();
    }
}
