using MediatR;
using InterviewExercise.Dtos.Customers;

namespace InterviewExercise.Queries.Customers
{
    public class GetCustomers: IRequest<IEnumerable<CustomerDetailDto>>
    {
    }
}