using InterviewExercise.Data;
using InterviewExercise.Dtos;
using Microsoft.EntityFrameworkCore;
using InterviewExercise.Commands.Customers;

namespace InterviewExercise.Handling.Customers
{
    public class UpdateCustomerContactMethodHandler : HandlerBase<UpdateCustomerContactMethod, SuccessOrFailureDto>
    {
        public UpdateCustomerContactMethodHandler(IDbContextFactory<UnitOfWork> uowFactory)
            : base(uowFactory)
        { }

        protected override async Task<SuccessOrFailureDto> HandleRequest(UpdateCustomerContactMethod request, UnitOfWork uow, CancellationToken cancellationToken)
        {
            var contactMethod = await uow.CustomerContactMethods.FirstOrDefaultAsync(ccm => ccm.Id == request.UpdateContactMethodDto.Id);//request.UpdateContactMethodDto.Id);

            var response = new SuccessOrFailureDto
            {
                Success = false,
                Message = "No contactMethod found"
            };

            if (contactMethod != null)
            {
                contactMethod.Type = request.UpdateContactMethodDto.Type;
                contactMethod.Value = request.UpdateContactMethodDto.Value;

                response.Message = "ContactMethod updated";
                response.Success = true;
            }

            await uow.SaveChangesAsync();

            return response;
        }
    }
}
