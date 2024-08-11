using InterviewExercise.Data;
using InterviewExercise.Commands.Invoices;
using InterviewExercise.Domain.Entities;

namespace InterviewExercise.Handling.Invoices
{
    public class CreateInvoiceHandler : HandlerBase<CreateInvoice, CreateInvoiceResponse>
    {
        public CreateInvoiceHandler(UnitOfWork uow) : base(uow)
        {
        }

        public override async Task<CreateInvoiceResponse> Handle(CreateInvoice request, CancellationToken cancellationToken)
        {
            var invoice = new Invoice
            {
                CustomerId = request.Invoice.CustomerId,
                Date = request.Invoice.Date,
                Description = request.Invoice.Description,
                InvoiceLines = request.Invoice.InvoiceLines
                .Select(il => new InvoiceLine
                {
                    Quantity = il.Quantity,
                    UnitPrice = il.UnitPrice
                }).ToList()
            };

            _uow.Invoices.Add(invoice);

            await _uow.SaveChangesAsync(cancellationToken);
            return new CreateInvoiceResponse
            {
                Success = true,
                InvoiceId = invoice.Id
            };
        }
    }
}
