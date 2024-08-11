using InterviewExercise.Dtos;
using InterviewExercise.Dtos.Invoices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InterviewExercise.Commands.Invoices;
using InterviewExercise.Queries.Invoices;
using FluentValidation.Results;
using InterviewExercise.Data;
using InterviewExercise.Validation.Commands.Invoices;

namespace InterviewExercise.Web.Api.Controllers
{
    [Route("api/invoices")]
    [AllowAnonymous]
    [ApiController]
    [ProducesResponseType(typeof(ValidationResult), StatusCodes.Status400BadRequest)]
    public class InvoiceController : CustomControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UnitOfWork _unitOfWork;

        public InvoiceController(IMediator mediator, UnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// GET invoices
        /// </summary>
        //GET api/invoices
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<InvoiceDetailDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInvoices()
        {
            var request = new GetInvoices();

            var response = await _mediator.Send(request);
            return  Ok(response);
        }

        /// <summary>
        /// Create invoice
        /// </summary>
        //POST api/invoices
        [HttpPost("")]
        [ProducesResponseType(typeof(CreateInvoiceResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceDto invoice)
        {
            var request = new CreateInvoice { Invoice = invoice };

            var result = await Validate<CreateInvoiceValidator, CreateInvoice>(request);
            if (!result.IsValid) return BadRequest(result);

            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Update invoice
        /// </summary>
        //PUT api/invoices/{invoiceId}
        [HttpPut("{invoiceId}")]
        [ProducesResponseType(typeof(SuccessOrFailureDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateInvoice(Guid invoiceId, [FromBody] InvoiceDto invoice)
        {
            var request = new UpdateInvoice 
            { 
                InvoiceId = invoiceId,
                Invoice = invoice 
            };

            var result = await Validate<UpdateInvoiceValidator, UpdateInvoice>(request);
            if (!result.IsValid) return BadRequest(result);

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
