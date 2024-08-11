using FluentValidation;
using InterviewExercise.Data;
using InterviewExercise.Dtos.Customers;


namespace InterviewExercise.Validation.Dtos.Customers
{
    public class CustomerDtoValidator : ValidatorBase<CustomerDto>
    {
        public CustomerDtoValidator(UnitOfWork uow) : base(uow)
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();

            When(c => c.CustomerContactMethods.Any(), () =>
            {
                RuleForEach(c => c.CustomerContactMethods)
                .SetValidator(new CustomerContactMethodDtoValidator(uow));
            });

        }
    }
}
