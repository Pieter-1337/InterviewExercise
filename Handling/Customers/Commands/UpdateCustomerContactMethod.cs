using InterviewExercise.Dtos;
using InterviewExercise.Dtos.Customers;
using MediatR;

namespace InterviewExercise.Handling.Customers.Commands
{
    public class UpdateCustomerContactMethod: IRequest<SuccessOrFailureDto>
    {
        public UpdateCustomerContactMethodDto UpdateContactMethodDto;
    }
}
