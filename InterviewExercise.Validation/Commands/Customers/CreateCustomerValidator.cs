using InterviewExercise.Data;
using InterviewExercise.Commands.Customers;
using InterviewExercise.Validation.Dtos.Customers;

namespace InterviewExercise.Validation.Commands.Customers
{
    public class CreateCustomerValidator: ValidatorBase<CreateCustomer>
    {
        public CreateCustomerValidator(UnitOfWork uow)
            : base(uow)
        {
            RuleFor(command => command.Customer)
                .SetValidator(new CustomerDtoValidator(uow));
        }
    }
}
