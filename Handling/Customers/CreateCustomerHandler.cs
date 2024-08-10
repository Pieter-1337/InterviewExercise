using InterviewExercise.Data;
using InterviewExercise.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using InterviewExercise.Dtos;
using InterviewExercise.Commands.Customers;
using InterviewExercise.Dtos.Customers;

namespace InterviewExercise.Handling.Customers
{
    public class CreateCustomerHandler : HandlerBase<CreateCustomer, CreateCustomerResponse>
    {
        public CreateCustomerHandler(IDbContextFactory<UnitOfWork> UowFactory)
            : base(UowFactory)
        { }


        protected override async Task<CreateCustomerResponse> HandleRequest(CreateCustomer request, UnitOfWork uow, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = request.Customer.FirstName,
                LastName = request.Customer.LastName,
                Address = request.Customer.Address,
                CustomerContactMethods = request.Customer.CustomerContactMethods.Select(ccm => new CustomerContactMethod { Type = ccm.Type, Value = ccm.Value}).ToList(),
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
