using Azure.Core;
using FormAPI.ApplicationCore.Helpers;
using FormAPI.Infrastructure.Validators.Candidate;
using FormAPI.Models.Entities;
using FormAPI.Models.Extensions;
using FormAPI.Models.Requests;
using FormAPI.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.ApplicationCore.Utils
{
	public static class CandidateServiceUtils
	{
		public static CandidateForm ConfigureCandidateForm(CandidateForm entity,string formId)
		{
			entity.CustomQuestions = entity.CustomQuestions.CheckType();
			entity.FormConfigurationId = formId;
			entity.id = Guid.NewGuid().ToString();
			return entity;
		}

		public static async Task CandidateFormValidation(CreateCandidateFormRequest request)
		{
			var CreateCandidateFormRequestValidator = new CreateCandidateFormRequestValidators();
			var validation = await CreateCandidateFormRequestValidator.ValidateAsync(request);
			if (!validation.IsValid) throw new CustomException(validation.Errors);
		}

	}
}
