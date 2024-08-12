
namespace InterviewExercise.Dtos.Customers
{
    public class CustomerDetailDto : CustomerDto
    {
        public Guid Id { get; set; }
        public new ICollection<CustomerContactMethodDetailDto> CustomerContactMethods { get; set; }
    }
}
