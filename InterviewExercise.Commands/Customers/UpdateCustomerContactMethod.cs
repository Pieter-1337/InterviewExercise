using InterviewExercise.Dtos;
using InterviewExercise.Dtos.Customers;
using MediatR;

namespace InterviewExercise.Commands.Customers
{
    public class UpdateCustomerContactMethod: IRequest<SuccessOrFailureDto>
    {
        public UpdateCustomerContactMethodDto UpdateContactMethodDto;
    }
}
