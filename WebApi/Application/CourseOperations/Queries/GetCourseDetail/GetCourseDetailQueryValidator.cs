using FluentValidation;

namespace WebApi.Application.CourseOperations.Queries.GetCourseDetail
{
    public class GetCourseDetailQueryValidator : AbstractValidator<GetCourseDetailQuery>
    {
        public GetCourseDetailQueryValidator()
        {
            RuleFor(query => query.courseId).GreaterThan(0);
        }
    }
}
