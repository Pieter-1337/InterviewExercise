using InterviewExercise.Data;
using InterviewExercise.Dtos.Customers;
using InterviewExercise.Queries.Customers;
using Microsoft.EntityFrameworkCore;

namespace InterviewExercise.Handling.Customers
{
    public class GetCustomersHandler : HandlerBase<GetCustomers, IEnumerable<CustomerDetailDto>>
    {
        public GetCustomersHandler(UnitOfWork uow)
            : base(uow)
        {
            
        }
        public override async Task<IEnumerable<CustomerDetailDto>> Handle(GetCustomers request, CancellationToken cancellationToken)
        {
            var customers = await _uow.Customers.ToListAsync(cancellationToken);
            return customers.Select(c => new CustomerDetailDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                //This probably should work differently with config in ModelBuilder not sure how this works in cosmosDB...
                CustomerContactMethods = _uow.CustomerContactMethods.Where(ccm => ccm.CustomerId == c.Id).Select(ccm => new CustomerContactMethodDetailDto
                {
                    Id= ccm.Id,
                    Type = ccm.Type,
                    Value = ccm.Value
                }).ToArray()
            });
        }
    }
}
