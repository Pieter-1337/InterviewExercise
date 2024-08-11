using InterviewExercise.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InterviewExercise.Handling
{
    public abstract class HandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly UnitOfWork _uow;
        protected HandlerBase(UnitOfWork uow)
        {
            _uow = uow;
        }


        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
