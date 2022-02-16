using FluentValidation;

namespace WebApi.Application.ExamOperations.Queries.GetExamDetail
{
    public class GetExamDetailQueryValidator : AbstractValidator<GetExamDetailQuery>
    {
        public GetExamDetailQueryValidator()
        {
            RuleFor(query => query.examId).GreaterThan(0);
        }
    }
}
