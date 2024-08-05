using InterviewExercise.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterviewExercise.Data
{
    public class UnitOfWork : DbContext
    {
        public UnitOfWork(DbContextOptions<UnitOfWork> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContactMethod> CustomerContactMethods { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoicesLine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToContainer(nameof(Customer))
                .HasPartitionKey(c => c.Id)
                .HasKey(c => c.Id);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.CustomerContactMethods)
                .WithOne(ccm => ccm.Customer)
                .HasForeignKey(ccm => ccm.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Invoices)
                .WithOne(i => i.Customer)
                .HasForeignKey(i => i.CustomerId);

            modelBuilder.Entity<CustomerContactMethod>()
                .ToContainer(nameof(CustomerContactMethod))
                .HasPartitionKey(c => c.Id)
                .HasKey(c => c.Id);

            modelBuilder.Entity<Invoice>()
                .ToContainer(nameof(Invoice))
                .HasPartitionKey(i => i.Id)
                .HasKey(i => i.Id);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.InvoiceLines)
                .WithOne(il => il.Invoice)
                .HasForeignKey(il => il.InvoiceId);

            modelBuilder.Entity<InvoiceLine>()
                .ToContainer(nameof(InvoiceLine))
                .HasPartitionKey(il => il.Id)
                .HasKey(il => il.Id);
        }

        public async Task EnsureCreatedAsync()
        {
            await Database.EnsureCreatedAsync();
        }
    }
}
