using System.Collections.ObjectModel;

namespace InterviewExercise.Domain.Entities
{
    public class Invoice: EntityBase
    {
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        //If we use automapper set ignore attributes on the relationships!
        #region relationships
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new Collection<InvoiceLine>();
        #endregion
    }
}
