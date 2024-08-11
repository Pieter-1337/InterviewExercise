using InterviewExercise.Data;
using InterviewExercise.Commands.Invoices;
using InterviewExercise.Domain.Entities;
using InterviewExercise.Dtos;

namespace InterviewExercise.Handling.Invoices
{
    public class UpdateInvoiceHandler : HandlerBase<UpdateInvoice, SuccessOrFailureDto>
    {
        public UpdateInvoiceHandler(UnitOfWork uow) : base(uow)
        {
        }

        public override async Task<SuccessOrFailureDto> Handle(UpdateInvoice request, CancellationToken cancellationToken)
        {
            var invoice = _uow.Invoices.FirstOrDefault(i => i.Id == request.InvoiceId);

            //Delete all exisiting invoiceLines
            var existingInvoiceLines = _uow.InvoicesLine
                .Where(il => il.InvoiceId == request.InvoiceId)
                .ToList();

            foreach(var il in existingInvoiceLines)
            {
                _uow.Remove(il);
            }

            invoice.Date = request.Invoice.Date;
            invoice.Description = request.Invoice.Description;
            
            //Add all new invoiceLines
            invoice.InvoiceLines = request.Invoice.InvoiceLines
                .Select(il => new InvoiceLine
                {
                    Quantity = il.Quantity,
                    UnitPrice = il.UnitPrice
                }).ToList();

            await _uow.SaveChangesAsync();

            var response = new SuccessOrFailureDto
            {
                Message = "Invoice updated",
                Success = true
            };

            return response;
        }
    }
}
