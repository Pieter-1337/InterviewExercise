using FluentValidation;
using InterviewExercise.Data;
using InterviewExercise.Dtos.Invoices;

namespace InterviewExercise.Validation.Dtos.Invoices
{
    public class InvoiceDtoValidator: ValidatorBase<InvoiceDto>
    {
        public InvoiceDtoValidator(UnitOfWork uow): base(uow)
        {
  
            RuleFor(i => i.Date).NotEmpty();
            RuleFor(i => i.Description).NotEmpty();

            RuleFor(i => i.InvoiceLines)
               .NotEmpty()
               .WithMessage("At least one InvoiceLine should be present on the invoice");

            RuleForEach(i => i.InvoiceLines)
           .SetValidator(new InvoiceLineDtoValidator(uow));
        }
    }
}
