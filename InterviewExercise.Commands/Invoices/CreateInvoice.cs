using InterviewExercise.Dtos;
using InterviewExercise.Dtos.Invoices;
using MediatR;


namespace InterviewExercise.Commands.Invoices
{
    public class CreateInvoice: IRequest<CreateInvoiceResponse>
    {
        public InvoiceDto Invoice { get; set; }
    }

    public class CreateInvoiceResponse : SuccessOrFailureDto
    {
        public Guid InvoiceId { get; set; }
    }
}
