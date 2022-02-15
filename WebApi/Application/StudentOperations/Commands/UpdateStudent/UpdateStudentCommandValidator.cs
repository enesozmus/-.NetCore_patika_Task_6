using FluentValidation;

namespace WebApi.Application.StudentOperations.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(command => command.StudentId).GreaterThan(0);
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.Birthday.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Number).GreaterThan(0);
        }
    }
}