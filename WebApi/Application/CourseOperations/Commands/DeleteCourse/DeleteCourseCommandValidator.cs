using FluentValidation;

namespace WebApi.Application.CourseOperations.Commands.DeleteCourse
{
    public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator()
        {
            RuleFor(command => command.courseId).GreaterThan(0);
        }
    }
}
