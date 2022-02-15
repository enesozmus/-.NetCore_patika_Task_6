using FluentValidation;

namespace WebApi.Application.StudentOperations.Queries.GetStudentDetail
{
    public class GetStudentDetailQueryValidator : AbstractValidator<GetStudentDetailQuery>
    {
        public GetStudentDetailQueryValidator()
        {
<<<<<<< HEAD
            RuleFor(query => query.studentId).GreaterThan(0);
=======
            RuleFor(query => query.StudentId).GreaterThan(0);
>>>>>>> 059afec4f1586d874d6656d52a0ae5a59233c77e
        }
    }
}
