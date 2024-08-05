using InterviewExercise.Data;
using InterviewExercise.Domain.Entities;
using InterviewExercise.Handling.Customers.Commands;
using Microsoft.EntityFrameworkCore;
using InterviewExercise.Dtos;

namespace InterviewExercise.Handling.Customers.Handlers
{
    public class CreateCustomerHandler: HandlerBase<CreateCustomer, CreateCustomerResponse>
    {
        public CreateCustomerHandler(IDbContextFactory<UnitOfWork> UowFactory) 
            : base(UowFactory) 
        { }
     

        protected override async Task<CreateCustomerResponse> HandleRequest(CreateCustomer request, UnitOfWork uow, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = "Pieter",
                LastName = "Bracke",
                Address = "Watergangstraat 6 9960 Assenede",
                CustomerContactMethods = [
                    new CustomerContactMethod
                    {
                        Type = ContactType.Email,
                        Value = "+32472321708"
                    }
                ]
            };
            uow.Customers.Add(customer);

            await uow.SaveChangesAsync(cancellationToken);
            return new CreateCustomerResponse
            {
                Success = true,
                CustomerId = customer.Id
            };
        }
    }
}
