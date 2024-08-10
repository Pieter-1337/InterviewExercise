namespace InterviewExercise.Dtos.Customers
{
    public class UpdateCustomerContactMethodDto: CustomerContactMethodDto
    {
        public Guid CustomerId { get; set; }
    }
}
