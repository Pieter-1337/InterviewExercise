using InterviewExercise.Dtos.Invoices;
using MediatR;

namespace InterviewExercise.Queries.Invoices
{
    public class GetInvoices: IRequest<IEnumerable<InvoiceDetailDto>>
    {
    }
}
