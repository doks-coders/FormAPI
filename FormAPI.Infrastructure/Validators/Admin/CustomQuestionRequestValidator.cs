using FluentValidation;
using FormAPI.Models.Helpers;
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

			RuleFor(x => x.Type)
				.Equal(y => Constants.TypeOptionsDynamic.All(u => u != y.Type) ? "Wrong Type" : y.Type).WithMessage("Please Select the right type")
		   .NotEmpty().WithMessage("Type should not be empty.")
		   .NotNull().WithMessage("Type should not be null.");

		}
	}
}
