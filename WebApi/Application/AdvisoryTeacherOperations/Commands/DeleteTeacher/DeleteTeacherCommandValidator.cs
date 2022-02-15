using FluentValidation;

namespace WebApi.Application.AdvisoryTeacherOperations.Commands.DeleteTeacher
{
    public class DeleteTeacherCommandValidator : AbstractValidator<DeleteTeacherCommand>
    {
        public DeleteTeacherCommandValidator()
        {
            RuleFor(command => command.AdvisoryId).GreaterThan(0);
        }
    }
}
