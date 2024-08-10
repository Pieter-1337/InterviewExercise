using InterviewExercise.Dtos;
using InterviewExercise.Dtos.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewExercise.Commands.Invoices
{
    public class UpdateInvoice: IRequest<SuccessOrFailureDto>
    {
        public UpdateInvoiceDto Invoice { get; set; }
    }
}
