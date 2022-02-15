using FluentValidation;

namespace WebApi.Application.CourseOperations.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
        }
    }
}
