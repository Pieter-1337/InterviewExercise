using InterviewExercise.Dtos.Customers;
using InterviewExercise.Commands.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using InterviewExercise.Dtos;
using FluentValidation.Results;
using InterviewExercise.Validation.Dtos;
using Microsoft.EntityFrameworkCore;
using InterviewExercise.Data;

namespace InterviewExercise.Web.Api.Controllers
{

    [Route("api/customers")]
    [AllowAnonymous]
    [ApiController]
    [ProducesResponseType(typeof(ValidationResult), StatusCodes.Status400BadRequest)]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDbContextFactory<UnitOfWork> _dbContextFactory;

        public CustomerController(IMediator mediator, IDbContextFactory<UnitOfWork> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _mediator = mediator;
        }

        /// <summary>
        /// Create customer
        /// </summary>
        //POST api/customers
        [HttpPost("")]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customer) 
        {
            var validator = new CustomerDtoValidator(_dbContextFactory);
            var validationResult = await validator.ValidateAsync(customer);

            if (!validationResult.IsValid) 
            {
                return BadRequest(validationResult);
            }

            var request = new CreateCustomer { Customer = customer };
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Update customerContactMethod
        /// </summary>
        //PUT api/customers/{customerId}/contactMethod
        [HttpPut("{customerId}/contactmethod")]
        [ProducesResponseType(typeof(SuccessOrFailureDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCustomerContactMethod(Guid customerId, [FromBody] UpdateCustomerContactMethodDto contactMethodDto)
        {
            //If we need the customerId pass it here in the constructor!
            //var validator = new UpdateCustomerContatMethodValidator(_dbContextFactory);
            //var validationResult = await validator.ValidateAsync(contactMethodDto);

            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult);
            //}

            contactMethodDto.CustomerId = customerId;
            var request = new UpdateCustomerContactMethod { UpdateContactMethodDto = contactMethodDto };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
