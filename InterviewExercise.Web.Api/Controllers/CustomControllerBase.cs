using FluentValidation;
using InterviewExercise.Data;
using InterviewExercise.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace InterviewExercise.Web.Api.Controllers
{
    public abstract class CustomControllerBase: ControllerBase
    {
        private readonly UnitOfWork _uow;
        protected CustomControllerBase(UnitOfWork uow) 
        {
            _uow = uow;
        }

        public virtual async Task<ValidationResult> Validate<TValidator, Dto>(Dto dto) where TValidator : ValidatorBase<Dto>
        {
            var validatorType = typeof(TValidator);
            var validator = (TValidator)Activator.CreateInstance(validatorType, _uow);
            var validationresult = await validator.ValidateAsync(dto);

            return validationresult;
        }
    }
}
