using FluentValidation;
using InterviewExercise.Data;
using InterviewExercise.Dtos.Customers;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace InterviewExercise.Validation.Dtos
{
    public class CustomerDtoValidator: ValidatorBase<CustomerDto>
    {
        public CustomerDtoValidator(IDbContextFactory<UnitOfWork> UowFactory) :base(UowFactory) 
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();

            When(c => c.CustomerContactMethods.Any(), () => 
            {
                RuleForEach(c => c.CustomerContactMethods)
                .Must(contactMethod => !string.IsNullOrEmpty(contactMethod.TypeAsString))
                .WithMessage("Each contact method must have a type.");

                RuleForEach(c => c.CustomerContactMethods)
                .Must(contactMethod =>
                    contactMethod.TypeAsString != null &&
                    (contactMethod.TypeAsString != "Email" || new EmailAddressAttribute().IsValid(contactMethod.Value)))
                .WithMessage("A valid email address is required when the contact method type is 'Email'.");
            });
        
        }
    }
}
