using InterviewExercise.Dtos.Customers;
using InterviewExercise.Handling.Customers.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using InterviewExercise.Dtos;

namespace InterviewExercise.Web.Api.Controllers
{

    [Route("api/customers")]
    [AllowAnonymous]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customer) 
        {
            var request = new CreateCustomer { Customer = customer };
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost("contactmethod")]
        [ProducesResponseType(typeof(SuccessOrFailureDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCustomerContactMethod([FromBody] UpdateCustomerContactMethodDto contactMethodDto)
        {
            var request = new UpdateCustomerContactMethod { UpdateContactMethodDto = contactMethodDto };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
