using InterviewExercise.Data;
using InterviewExercise.Domain.Entities;
using InterviewExercise.Commands.Customers;

namespace InterviewExercise.Handling.Customers
{
    public class CreateCustomerHandler : HandlerBase<CreateCustomer, CreateCustomerResponse>
    {
        public CreateCustomerHandler(UnitOfWork uow)
            : base(uow)
        { }


        public override async Task<CreateCustomerResponse> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = request.Customer.FirstName,
                LastName = request.Customer.LastName,
                Address = request.Customer.Address,
                CustomerContactMethods = request.Customer.CustomerContactMethods.Select(ccm => new CustomerContactMethod { Type = ccm.Type, Value = ccm.Value}).ToList(),
            };
            _uow.Customers.Add(customer);

            await _uow.SaveChangesAsync(cancellationToken);
            return new CreateCustomerResponse
            {
                Success = true,
                CustomerId = customer.Id
            };
        }
    }
}
