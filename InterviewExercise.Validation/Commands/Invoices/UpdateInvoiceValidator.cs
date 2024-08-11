using FluentValidation;
using InterviewExercise.Commands.Invoices;
using InterviewExercise.Data;
using InterviewExercise.Validation.Dtos.Invoices;
using Microsoft.EntityFrameworkCore;

namespace InterviewExercise.Validation.Commands.Invoices
{
    public class UpdateInvoiceValidator: ValidatorBase<UpdateInvoice>
    {
        public UpdateInvoiceValidator(UnitOfWork uow)
            : base(uow)
        {
            RuleFor(command => command.InvoiceId)
                .MustAsync(async (id, cancellationToken) => await InvoiceExists(id))
                .WithMessage("The invoice you are trying to update does not exist");

            RuleFor(command => command.Invoice.CustomerId)
                .MustAsync(async (customerId, cancellationtoken) => await CustomerExists(customerId))
                .WithMessage("The customer for which you are trying to update the invoice does not exist");

            RuleFor(i => i.Invoice).SetValidator(new InvoiceDtoValidator(uow));
        }

        private async Task<bool> InvoiceExists(Guid id)
        {
            return await _uow.Invoices.FirstOrDefaultAsync(i => i.Id == id) != null;
        }

        private async Task<bool> CustomerExists(Guid id)
        {
            return await _uow.Customers.FirstOrDefaultAsync(c => c.Id == id) != null;
        }
    }
}
