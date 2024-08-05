namespace InterviewExercise.Domain.Entities
{
    public class InvoiceLine: EntityBase
    { 
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
