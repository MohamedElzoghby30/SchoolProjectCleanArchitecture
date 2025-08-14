using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validation
{
    public class AddStudentValidatior : AbstractValidator<AddStudentCommand>
    {
        #region Fildes
        private readonly IStudentService _studentService;
        #endregion
        #region Constractor
        public AddStudentValidatior(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropartyName}Must not empty ")
                .NotNull().WithMessage("{PropartyName} must not null")
                .MaximumLength(100).WithMessage("{PropartyName} have Max length 100 ");
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) =>!await _studentService.IsExsitAsync(Key))
                .WithMessage("Is Exsit");
        }
        #endregion
    }
}
