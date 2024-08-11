using InterviewExercise.Data;
using InterviewExercise.Dtos;
using Microsoft.EntityFrameworkCore;
using InterviewExercise.Commands.Customers;

namespace InterviewExercise.Handling.Customers
{
    public class UpdateCustomerContactMethodHandler : HandlerBase<UpdateCustomerContactMethod, SuccessOrFailureDto>
    {
        public UpdateCustomerContactMethodHandler(UnitOfWork uow)
            : base(uow)
        { }

        public override async Task<SuccessOrFailureDto> Handle(UpdateCustomerContactMethod request, CancellationToken cancellationToken)
        {
            var contactMethod = await _uow.CustomerContactMethods.FirstOrDefaultAsync(ccm => ccm.Id == request.ContactMethodId);

            contactMethod.Type = request.ContactMethodDto.Type;
            contactMethod.Value = request.ContactMethodDto.Value;

            await _uow.SaveChangesAsync();

            var response = new SuccessOrFailureDto
            {
                Message = "ContactMethod updated",
                Success = true
            };

            return response;
        }
    }
}
