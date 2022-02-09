using FluentValidation;

namespace WebApi.Application.StudentOperations.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(command => command.Model.Number).GreaterThan(103);
            RuleFor(command => command.Model.Birthday.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(2);
        }
    }
}
