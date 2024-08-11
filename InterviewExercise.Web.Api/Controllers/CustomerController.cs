using InterviewExercise.Dtos.Customers;
using InterviewExercise.Commands.Customers;
using InterviewExercise.Queries.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using InterviewExercise.Dtos;
using FluentValidation.Results;
using InterviewExercise.Data;
using InterviewExercise.Validation.Commands.Customers;

namespace InterviewExercise.Web.Api.Controllers
{

    [Route("api/customers")]
    [AllowAnonymous]
    [ApiController]
    [ProducesResponseType(typeof(ValidationResult), StatusCodes.Status400BadRequest)]
    public class CustomerController : CustomControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UnitOfWork _unitOfWork;

        public CustomerController(IMediator mediator, UnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Get customer
        /// </summary>
        //GET api/customers
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<CustomerDetailDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomers()
        {
            var request = new GetCustomers();

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// Create customer
        /// </summary>
        //POST api/customers
        [HttpPost("")]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customer) 
        {
            var request = new CreateCustomer { Customer = customer };

            //This code block can be put in an action filter so it is preprocessed before the action, => overkill for this exercise!
            var result = await Validate<CreateCustomerValidator, CreateCustomer>(request);
            if (!result.IsValid) return BadRequest(result);

            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Update customerContactMethod
        /// </summary>
        //PUT api/customers/{customerId}/contactMethod/{contactMethodId}
        [HttpPut("{customerId}/contactmethod/{contactMethodId}")]
        [ProducesResponseType(typeof(SuccessOrFailureDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCustomerContactMethod(Guid customerId, Guid contactMethodId, [FromBody] CustomerContactMethodDto contactMethodDto)
        {
            var request = new UpdateCustomerContactMethod
            {
                ContactMethodId = contactMethodId,
                CustomerId = customerId,
                ContactMethodDto = contactMethodDto
            };
         
            var result = await Validate<UpdateCustomerContactMethodValidator, UpdateCustomerContactMethod>(request);
            if (!result.IsValid) return BadRequest(result);

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
