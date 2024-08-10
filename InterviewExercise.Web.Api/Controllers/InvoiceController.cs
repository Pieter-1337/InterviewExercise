using InterviewExercise.Dtos;
using InterviewExercise.Dtos.Invoices;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InterviewExercise.Commands.Invoices;

namespace InterviewExercise.Web.Api.Controllers
{
    [Route("api/invoices")]
    [AllowAnonymous]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
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
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Update invoice
        /// </summary>
        //PUT api/invoices/{invoiceId}
        [HttpPut("{invoiceId}")]
        [ProducesResponseType(typeof(SuccessOrFailureDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateInvoice(Guid invoiceId, [FromBody] UpdateInvoiceDto updateInvoiceDto)
        {
            updateInvoiceDto.Id = invoiceId;
            var request = new UpdateInvoice { Invoice = updateInvoiceDto };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
