
using InterviewExercise.Data;
using InterviewExercise.Dtos.Invoices;
using InterviewExercise.Queries.Invoices;
using Microsoft.EntityFrameworkCore;

namespace InterviewExercise.Handling.Invoices
{
    public class GetInvoicesHandler: HandlerBase<GetInvoices, IEnumerable<InvoiceDetailDto>>
    {
        public GetInvoicesHandler(UnitOfWork uow)
            : base(uow)
        {  
        }

        public override async Task<IEnumerable<InvoiceDetailDto>> Handle(GetInvoices request, CancellationToken cancellationToken)
        {
            var invoices = await _uow.Invoices.ToListAsync(cancellationToken);
            return invoices.Select(i => new InvoiceDetailDto
            {
                Id = i.Id,
                CustomerId = i.CustomerId,
                Date = i.Date,
                Description = i.Description,
                //This probably should work differently with config in ModelBuilder not sure how this works in cosmosDB...
                InvoiceLines = _uow.InvoicesLine.Where(il => il.InvoiceId == i.Id).Select(il => new InvoiceLineDetailDto
                {
                    Id = il.Id,
                    Quantity = il.Quantity,
                    UnitPrice = il.UnitPrice
                }).ToArray()
            });
        }
    }
}
