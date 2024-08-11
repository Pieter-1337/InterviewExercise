using InterviewExercise.Dtos;
using InterviewExercise.Dtos.Customers;
using MediatR;

namespace InterviewExercise.Commands.Customers
{
    public class UpdateCustomerContactMethod: IRequest<SuccessOrFailureDto>
    {
        public Guid ContactMethodId { get; set; }
        public Guid CustomerId { get; set; }
        public CustomerContactMethodDto ContactMethodDto { get; set; }
    }
}
