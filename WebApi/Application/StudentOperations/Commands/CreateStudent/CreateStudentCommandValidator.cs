using FluentValidation;

namespace WebApi.Application.StudentOperations.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
<<<<<<< HEAD
            RuleFor(command => command.Model.Number).GreaterThan(103);
            RuleFor(command => command.Model.Birthday.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(2);
=======
            // ***** under development ***** //
            //RuleFor(command => command.Model.Number).GreaterThan(103);
            //RuleFor(command => command.Model.Birthday.Date).NotEmpty().LessThan(DateTime.Now.Date);
            //RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(2);
            //RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(2);
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
        }
    }
}
