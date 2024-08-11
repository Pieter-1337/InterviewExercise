using FluentValidation;
using InterviewExercise.Data;
using InterviewExercise.Dtos;
using InterviewExercise.Dtos.Customers;
using System.ComponentModel.DataAnnotations;

namespace InterviewExercise.Validation.Dtos.Customers
{
    public class CustomerContactMethodDtoValidator : ValidatorBase<CustomerContactMethodDto>
    {
        public CustomerContactMethodDtoValidator(UnitOfWork uow)
            : base(uow)
        {
            RuleFor(contactMethod => contactMethod.TypeAsString)
                .NotEmpty().WithMessage("A contact method must have a type.");

            RuleFor(contactMethod => contactMethod.Value)
                .NotEmpty().WithMessage("A contact method must have a value.");

            When(c => c.TypeAsString == ContactType.Email.ToString(), () =>
            {
                RuleFor(contactMethod => contactMethod.Value)
               .Must((value) => new EmailAddressAttribute().IsValid(value))
               .WithMessage("A valid email address is required when the contact method type is 'Email'.");
            });
        }

    }
}
