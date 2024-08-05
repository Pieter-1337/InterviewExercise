using InterviewExercise.Dtos;
using InterviewExercise.Dtos.Customers;
using MediatR;

namespace InterviewExercise.Handling.Customers.Commands
{
    public class CreateCustomer : IRequest<CreateCustomerResponse>
    {
        public CustomerDto Customer { get; set; }
    }

    public class CreateCustomerResponse : SuccessOrFailureDto
    {
        public Guid CustomerId { get; set; }
    }
}
