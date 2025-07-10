using Application.Activities.DTOs;
using FluentValidation;

namespace Application.Activities.Validators
{
    public class BaseActivityValidator<T, TDto> : AbstractValidator<T> where TDto : BaseActivityDto
    {
        public BaseActivityValidator(Func<T, TDto> selector)
        {
            RuleFor(x => selector(x).Title).NotEmpty().WithMessage("Title is required").MaximumLength(100).WithMessage("Too long");
            RuleFor(x => selector(x).Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => selector(x).Date).GreaterThan(DateTime.UtcNow).WithMessage("Future dates pls");
            RuleFor(x => selector(x).Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => selector(x).City).NotEmpty().WithMessage("Citx is required");
            RuleFor(x => selector(x).Venue).NotEmpty().WithMessage("Venue is required");
            RuleFor(x => selector(x).Latitude).NotEmpty().WithMessage("Req").InclusiveBetween(-90, 90).WithMessage("Latt must be -90,90");
            RuleFor(x => selector(x).Longitude).NotEmpty().WithMessage("Req").InclusiveBetween(-180, 180).WithMessage("Long must be -180,180");
        }
    }
}
