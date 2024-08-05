using InterviewExercise.Data;
using InterviewExercise.Dtos;
using InterviewExercise.Handling.Customers.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewExercise.Handling.Customers.Handlers
{
    public class UpdateCustomerContactMethodHandler : HandlerBase<UpdateCustomerContactMethod, SuccessOrFailureDto>
    {
        public UpdateCustomerContactMethodHandler(IDbContextFactory<UnitOfWork> uowFactory)
            : base(uowFactory) 
        { }

        protected override async Task<SuccessOrFailureDto> HandleRequest(UpdateCustomerContactMethod request, UnitOfWork uow, CancellationToken cancellationToken)
        {
            var contactMethod = await uow.CustomerContactMethods.FirstOrDefaultAsync(ccm => ccm.Id == Guid.Parse("951ac738-2578-4903-ae32-5f2e110f57cf"));//request.UpdateContactMethodDto.Id);

            var response = new SuccessOrFailureDto
            {
                Success = false,
                Message = "No contactMethod found"
            };
            
            if (contactMethod != null) 
            {
                contactMethod.Type = request.UpdateContactMethodDto.ContactType;
                contactMethod.Value = request.UpdateContactMethodDto.Value;

                response.Message = "ContactMethod updated";
                response.Success = true;
            }

            await uow.SaveChangesAsync();

            return response;
        }
    }
}
