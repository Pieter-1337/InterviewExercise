using FluentValidation;
using InterviewExercise.Data;
using Microsoft.EntityFrameworkCore;

namespace InterviewExercise.Validation
{
    public abstract class ValidatorBase<T> : AbstractValidator<T>
    {
        public readonly UnitOfWork _uow;
        public ValidatorBase(UnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
