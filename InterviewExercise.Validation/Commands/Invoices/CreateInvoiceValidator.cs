using FluentValidation;
using InterviewExercise.Commands.Invoices;
using InterviewExercise.Data;
using InterviewExercise.Validation.Dtos.Invoices;
using Microsoft.EntityFrameworkCore;

namespace InterviewExercise.Validation.Commands.Invoices
{
    public class CreateInvoiceValidator: ValidatorBase<CreateInvoice>
    {
        public CreateInvoiceValidator(UnitOfWork uow)
            : base(uow)
        {
            RuleFor(command => command.Invoice.CustomerId)
                .MustAsync(async (customerId, cancellationtoken) => await CustomerExists(customerId))
                .WithMessage("The customer for which you are trying to create the invoice does not exist");

            RuleFor(command => command.Invoice)
                .SetValidator(new InvoiceDtoValidator(uow));
        }

        private async Task<bool> CustomerExists(Guid id)
        {
            return await _uow.Customers.FirstOrDefaultAsync(c => c.Id == id) != null;
        }
    }
}
