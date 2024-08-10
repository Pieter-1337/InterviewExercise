namespace InterviewExercise.Dtos.Invoices
{
    public class InvoiceLineDto: DtoBase
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
