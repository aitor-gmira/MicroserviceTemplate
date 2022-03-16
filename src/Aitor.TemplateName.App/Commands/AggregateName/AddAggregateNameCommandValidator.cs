using FluentValidation;

namespace Aitor.TemplateName.App.Commands.AggregateName
{
    public class AddAggregateNameCommandValidator : AbstractValidator<AddAggregateNameCommand>
    {
        public AddAggregateNameCommandValidator()
        {
            RuleFor(x => x.Dto).NotNull();
            RuleFor(x => x.Dto.Name).NotNull();
            RuleFor(x => x.Dto.Name).Length(1, 120);
        }
    }
}
