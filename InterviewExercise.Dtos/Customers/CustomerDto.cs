using System.Collections.ObjectModel;

namespace InterviewExercise.Dtos.Customers
{
    public class CustomerDto : DtoBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public ICollection<CustomerContactMethodDto> CustomerContactMethods { get; set; } = new Collection<CustomerContactMethodDto>();
    }
}
