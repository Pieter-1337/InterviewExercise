using InterviewExercise.Dtos;
using InterviewExercise.Dtos.Invoices;
using MediatR;

namespace InterviewExercise.Commands.Invoices
{
    public class UpdateInvoice: IRequest<SuccessOrFailureDto>
    {
        public Guid InvoiceId { get; set; }
        public InvoiceDto Invoice { get; set; }
    }
}
