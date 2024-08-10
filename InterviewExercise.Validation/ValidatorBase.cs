using FluentValidation;
using InterviewExercise.Data;
using Microsoft.EntityFrameworkCore;

namespace InterviewExercise.Validation
{
    public abstract class ValidatorBase<T> : AbstractValidator<T>
    {
        private readonly IDbContextFactory<UnitOfWork> _UowFactory;
        protected ValidatorBase(IDbContextFactory<UnitOfWork> UowFactory)
        {
            _UowFactory = UowFactory;
        }

        protected virtual async Task<UnitOfWork> GetUnitOfWorkAsync(CancellationToken cancellationToken)
        {
            return await _UowFactory.CreateDbContextAsync(cancellationToken);
        }

        //Override validateAsync here so we can fetch UnitOfworkAsync and then call base.
        public override async Task<FluentValidation.Results.ValidationResult> ValidateAsync(
        ValidationContext<T> context,
        CancellationToken cancellationToken = default)
        {
            var unitOfWork = await GetUnitOfWorkAsync(cancellationToken);

            var validationResult = await base.ValidateAsync(context, cancellationToken);

            return validationResult;
        }

    }
}
