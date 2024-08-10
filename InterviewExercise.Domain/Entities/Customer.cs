using System.Collections.ObjectModel;

namespace InterviewExercise.Domain.Entities
{
    public class Customer : EntityBase
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Exercise didn't demand multipe typed addresses, so implemented it as a string property here
        //In a real world I would not recommend this, and would have created a seperate address Entity that has a one to many relationship with the customer (multipe addresses possible for single customer...)
        public string Address { get; set; }
        #endregion

        //If we use automapper set ignore attributes on the relationships!
        #region relationships
        public virtual ICollection<CustomerContactMethod> CustomerContactMethods { get; set; } = new Collection<CustomerContactMethod>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new Collection<Invoice>();
        #endregion
    }
}
