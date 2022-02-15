using FluentValidation;

namespace WebApi.Application.AdvisoryTeacherOperations.Queries.GetTeacherDetail
{
    public class GetTeacherDetailQueryValidator : AbstractValidator<GetTeacherDetailQuery>
    {
        public GetTeacherDetailQueryValidator()
        {
            RuleFor(query => query.AdvisoryId).GreaterThan(0);
        }
    }
}