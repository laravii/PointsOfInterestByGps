using FluentValidation;
using PointsOfInterestByGps.Requests;

namespace PointsOfInterestByGps.Validations
{
    public class PointsLocaleCordinateValidator : AbstractValidator<PointsLocaleCordinateRequest>
    {
        public PointsLocaleCordinateValidator()
        {
            RuleFor(request => request.CoordinateX)
                .NotEmpty()
                .NotNull()
                .GreaterThan(1)
                .WithMessage("Por favor, insira um número positivo maior que 0");

            RuleFor(request => request.CoordinateY)
                .NotEmpty()
                .NotNull()
                .GreaterThan(1)
                .WithMessage("Por favor, insira um número positivo maior que 0"); 

            RuleFor(request => request.PointDescription)
                .NotNull()
                .NotEmpty()
                .Matches(@"^[a-zA-Z_:][a-zA-Z0-9_>]*$");
        }
    }
}
