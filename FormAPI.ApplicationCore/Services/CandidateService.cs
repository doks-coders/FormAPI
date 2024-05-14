using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Infrastructure.Data;
using FormAPI.Infrastructure.Validators.Candidate;
using FormAPI.Models.Extensions;
using FormAPI.Models.Helpers;
using FormAPI.Models.Requests;
using FormAPI.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.ApplicationCore.Services
{
	public class CandidateService:ICandidateService
	{

		public MapperProfiles mapper = new();
		private readonly ApplicationDataContext _db;

		public CandidateService(ApplicationDataContext db)
		{
			_db = db;
		}

		/// <summary>
		/// This method gets the form configuration from the database, this is used by the frontend developers to modify the login page
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public async Task<FormConfigurationsResponse> GetFormConfiguration(string id)
		{
			var item = await _db.FormConfigurations.GetItem(id);
			if (item == null) throw new Exception("Specific Form Not Found");
			var res = mapper.FormConfigurationToFormConfigurationResponse(item);
			var questions = await _db.CustomQuestions.GetItemCategory(res.id, "FormConfigId");
			res.CustomQuestions = questions.GetChildren();
			return res;
		}

		/// <summary>
		/// This is method is used for submitting the form to the database
		/// </summary>
		/// <param name="request"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public async Task SubmitForm(CreateCandidateFormRequest request, string formId)
		{
			var CreateCandidateFormRequestValidator = new CreateCandidateFormRequestValidators();
			var validation = await CreateCandidateFormRequestValidator.ValidateAsync(request);

			if (!validation.IsValid) throw new Exception(string.Join(", ", validation.Errors.Select(e => e.ErrorMessage).ToArray()));
			


			var entity = mapper.CandidateFormRequestToCandidateForm(request);
			entity.FormConfigurationId = formId;
			entity.id = Guid.NewGuid().ToString();
			if(await _db.CandidateForms.UpsertItem(entity))
			{
				return;
			}
			throw new Exception("Did not save Successfully");
		}
	}
}
