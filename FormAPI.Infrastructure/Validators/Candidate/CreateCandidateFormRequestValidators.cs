using FluentValidation;
using FormAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Infrastructure.Validators.Candidate
{
	public class CreateCandidateFormRequestValidators : AbstractValidator<CreateCandidateFormRequest>
	{
		public CreateCandidateFormRequestValidators()
		{
			RuleFor(x => x.Email.Value)
		   .NotEmpty().WithMessage("Email Address should not be empty.")
		   .NotNull().WithMessage("Email Address should not be null.")
		   .EmailAddress().WithMessage("Email address is invalid.");

			RuleFor(x => x.FirstName.Value)
		   .NotEmpty().WithMessage("First Name should not be empty.")
		   .NotNull().WithMessage("First Name should not be null.");


			RuleFor(x => x.LastName.Value)
		   .NotEmpty().WithMessage("Last Name should not be empty.")
		   .NotNull().WithMessage("Last Name should not be null.");
		  

		}
	}
}
