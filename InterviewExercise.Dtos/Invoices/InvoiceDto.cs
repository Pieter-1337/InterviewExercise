using System.Collections.ObjectModel;

namespace InterviewExercise.Dtos.Invoices
{
    public class InvoiceDto
    {
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public virtual decimal TotalAmount => InvoiceLines?.Sum(il => il.Quantity * il.UnitPrice) ?? 0M;
        public ICollection<InvoiceLineDto> InvoiceLines { get; set; } = new Collection<InvoiceLineDto>();
    }
}
