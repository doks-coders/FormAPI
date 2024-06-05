using FormAPI.ApplicationCore.Helpers;
using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.ApplicationCore.Utils;
using FormAPI.Infrastructure.Data;
using FormAPI.Infrastructure.Validators.Candidate;
using FormAPI.Models.Extensions;
using FormAPI.Models.Helpers;
using FormAPI.Models.Requests;
using FormAPI.Models.Responses;

namespace FormAPI.ApplicationCore.Services
{
	public class CandidateService : ICandidateService
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
			if (item == null) throw new CustomException(ErrorStatusEnums.FormNotFound);
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
			await CandidateServiceUtils.CandidateFormValidation(request);
			var entity = mapper.CandidateFormRequestToCandidateForm(request);
			entity = CandidateServiceUtils.ConfigureCandidateForm(entity, formId);
			if (await _db.CandidateForms.UpsertItem(entity))
			{
				return;
			}
			throw new Exception("Did not save Successfully");
		}
	}
}
