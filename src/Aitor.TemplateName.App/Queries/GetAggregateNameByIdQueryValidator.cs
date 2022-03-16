using FluentValidation;

namespace Aitor.TemplateName.App.Queries
{
    public class GetAggregateNameByIdQueryValidator : AbstractValidator<GetAggregateNameByIdQuery>
    {
        public GetAggregateNameByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Id).NotNull();
        }
    }
}
