using FluentValidation;
using FormAPI.Models.Requests;

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
