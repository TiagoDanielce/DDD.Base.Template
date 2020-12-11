using FluentValidation;

namespace DDD.Base.Template.Infra.CrossCutting.Extensions.Mediator.Commands
{
    public abstract class Command<TValidator> : Validable where TValidator : IValidator
    {
        public override bool Validate() => UseValidator<TValidator>(this);
    }
}
