using InterviewExercise.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewExercise.Handling
{
    public abstract class HandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IDbContextFactory<UnitOfWork> _UowFactory;
        protected HandlerBase(IDbContextFactory<UnitOfWork> UowFactory)
        {
            _UowFactory = UowFactory;
        }

        //Must be public due to inheriting from IRequestHandler...
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            using var uow = await GetUnitOfWorkAsync(cancellationToken);
            return await HandleRequest(request, uow, cancellationToken);
        }
        protected virtual async Task<UnitOfWork> GetUnitOfWorkAsync(CancellationToken cancellationToken)
        {
            return await _UowFactory.CreateDbContextAsync(cancellationToken);
        }

        protected abstract Task<TResponse> HandleRequest(TRequest request, UnitOfWork uow, CancellationToken cancellationToken);
    }
}
