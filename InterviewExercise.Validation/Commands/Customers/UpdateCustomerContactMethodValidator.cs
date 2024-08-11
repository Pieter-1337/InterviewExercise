using FluentValidation;
using InterviewExercise.Commands.Customers;
using InterviewExercise.Data;
using InterviewExercise.Validation.Dtos.Customers;
using Microsoft.EntityFrameworkCore;

namespace InterviewExercise.Validation.Commands.Customers
{
    public class UpdateCustomerContactMethodValidator: ValidatorBase<UpdateCustomerContactMethod>
    {
        public UpdateCustomerContactMethodValidator(UnitOfWork uow)
            : base(uow)
        
        {
            RuleFor(command => command.ContactMethodId)
                .MustAsync(async (id, cancellationToken) => await ContactMethodExists(id))
                .WithMessage("The customer for the contactMethod you are trying to update does not exist");
            RuleFor(command => command.CustomerId)
                .MustAsync(async (customerId, cancellationtoken) => await CustomerExists(customerId))
                .WithMessage("The customer for which you are trying to update the contactMethod does not exist");
            RuleFor(command => command.ContactMethodDto)
                .SetValidator(new CustomerContactMethodDtoValidator(uow));
        }

        private async Task<bool> ContactMethodExists(Guid id)
        {
            return await _uow.CustomerContactMethods.FirstOrDefaultAsync(c => c.Id == id) != null;
        }

        private async Task<bool> CustomerExists(Guid id)
        {
            return await _uow.Customers.FirstOrDefaultAsync(c => c.Id == id) != null;
        }
        
    }
}
