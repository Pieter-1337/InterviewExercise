using FluentValidation;
using InterviewExercise.Data;
using InterviewExercise.Dtos.Invoices;

namespace InterviewExercise.Validation.Dtos.Invoices
{
    public class InvoiceLineDtoValidator: ValidatorBase<InvoiceLineDto>
    {
        public InvoiceLineDtoValidator(UnitOfWork uow)
            : base(uow)
        {
            RuleFor(il => il.UnitPrice).NotEmpty();
            RuleFor(il => il.Quantity).NotEmpty();
        }
    }
}
