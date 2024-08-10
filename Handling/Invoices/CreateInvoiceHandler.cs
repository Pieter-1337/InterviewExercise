using InterviewExercise.Data;
using InterviewExercise.Commands.Invoices;
using Microsoft.EntityFrameworkCore;

namespace InterviewExercise.Handling.Invoices
{
    public class CreateInvoiceHandler : HandlerBase<CreateInvoice, CreateInvoiceResponse>
    {
        public CreateInvoiceHandler(IDbContextFactory<UnitOfWork> UowFactory) : base(UowFactory)
        {
        }

        protected override async Task<CreateInvoiceResponse> HandleRequest(CreateInvoice request, UnitOfWork uow, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
