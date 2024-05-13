using FluentValidation;
using FormAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.Infrastructure.Validators.Admin
{

	public class CustomQuestionRequestValidator : AbstractValidator<CustomQuestionRequest>
	{
		public CustomQuestionRequestValidator()
		{
			RuleFor(x => x.Question)
		   .NotEmpty().WithMessage("Question should not be empty.")
		   .NotNull().WithMessage("Question should not be null.");

		}
	}
}
