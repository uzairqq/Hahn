using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Hahn.ApplicationProcess.May2020.Core.Dto;
using Hahn.ApplicationProcess.May2020.Core.Models;

namespace Hahn.ApplicationProcess.May2020.Core.Validators
{
    public class ApplicantValidator : AbstractValidator<ApplicantDto>
    {
        public ApplicantValidator()
        {
            RuleFor(x => x.Name).MinimumLength(5)
                .WithMessage("Name must be minimum 5 characters");

            RuleFor(x => x.FamilyName).MinimumLength(5)
                .WithMessage("FamilyName must be minimum 5 characters");


            RuleFor(x => x.Address).MinimumLength(10)
                .WithMessage("Address must be minimum 10 characters");

              RuleFor(s => s.EmailAddress).NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Your Email address is not valid");

              RuleFor(x => x.Age).InclusiveBetween(20, 60)
                  .WithMessage("Age must be between 20 and 60");

              RuleFor(x => x.Hired).NotEmpty()
                  .WithMessage("Hired Is Empty");
        }
    }
}
