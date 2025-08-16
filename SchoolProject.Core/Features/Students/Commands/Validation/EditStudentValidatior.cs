using FluentValidation;
using FluentValidation.Validators;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Validation
{
    public class EditStudentValidatior : AbstractValidator<EditStudentCommand>
    {
        #region Fildes
        private readonly IStudentService _studentService;
        #endregion
        #region Constractor
        public EditStudentValidatior(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationsRules();
           // ApplyCustomValidationsRules();
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
        //public void ApplyCustomValidationsRules()
        //{
        //    RuleFor(x => x.Name)
        //        .MustAsync(async (model,Key, CancellationToken) => !await _studentService.IsExsitAsync(Key,model.StudID))
        //        .WithMessage("Is Exsit");
        //}
        #endregion
    }
}
