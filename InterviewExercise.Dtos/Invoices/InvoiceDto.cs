namespace InterviewExercise.Dtos.Invoices
{
    public class InvoiceDto: DtoBase
    {
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount => InvoiceLines?.Sum(il => il.Quantity * il.UnitPrice) ?? 0M;
        public IEnumerable<InvoiceLineDto> InvoiceLines { get; set; } = Enumerable.Empty<InvoiceLineDto>();
    }
}
