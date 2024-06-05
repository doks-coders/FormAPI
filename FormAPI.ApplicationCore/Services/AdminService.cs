using FormAPI.ApplicationCore.Helpers;
using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.ApplicationCore.Utils;
using FormAPI.Infrastructure.Data;
using FormAPI.Infrastructure.Validators.Admin;
using FormAPI.Models.Entities;
using FormAPI.Models.Extensions;
using FormAPI.Models.Helpers;
using FormAPI.Models.Requests;
using FormAPI.Models.Responses;
using Serilog;

namespace FormAPI.ApplicationCore.Services
{
	public class AdminService : IAdminService
	{

		private readonly MapperProfiles mapper = new();
		private readonly ApplicationDataContext _db;

		public AdminService(ApplicationDataContext db)
		{
			_db = db;
		}

		/// <summary>
		/// This is method creates the a form configuration that will be used to display information to the user
		/// </summary>
		/// <param name="properties"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public async Task<string> CreateForm(CreateFormConfigurationRequest properties)
		{
			var item = mapper.CreateFormConfigurationRequestToFormConfiguration(properties);
			item  = AdminServiceUtils.ConfigureFormConfiguration(item);
			item.id = Guid.NewGuid().ToString();

			if (await _db.FormConfigurations.UpsertItem(item))
			{
				return item.id;
			}
			throw new CustomException(ErrorStatusEnums.FormCreationFailed);
		}

		/// <summary>
		/// This method get's the specified form configuration
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public async Task<FormConfiguration> GetFormConfig(string id)
		{
			var res = await _db.FormConfigurations.GetItem(id);
			if (res == null) throw new CustomException(ErrorStatusEnums.FormNotFound);
			return res;
		}

		/// <summary>
		/// This method updates the previously saved configured form
		/// </summary>
		/// <param name="request"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public async Task UpdateForm(UpdateFormConfigurationRequest request, string id)
		{
			var item = await _db.FormConfigurations.GetItem(id);
			if (item == null) throw new CustomException(ErrorStatusEnums.FormNotFound);

			var updatedProperty = mapper.UpdateFormConfigurationRequestToFormConfiguration(request);
			updatedProperty = AdminServiceUtils.ConfigureFormConfiguration(updatedProperty);
			updatedProperty = updatedProperty.GetIdandPartitionKey(item);
			if (await _db.FormConfigurations.UpsertItem(updatedProperty))
			{
				return;
			}
			throw new CustomException(ErrorStatusEnums.FormUpdateFailed);

		}

		public async Task<string> CreateCustomQuestion(CustomQuestionRequest request, string formConfigId)
		{

			await AdminServiceUtils.ValidateQuestion(request);
			var question = mapper.CustomQuestionRequestToCustomQuestion(request);

			//Configure Question
			question = AdminServiceUtils.ConfigureQuestion(question, formConfigId);
			if (await _db.CustomQuestions.UpsertItem(question))
			{
				return question.id;
			}
			throw new CustomException(ErrorStatusEnums.QuestionCreationFailed);
		}

		public async Task UpdateCustomQuestion(CustomQuestionRequest request, string id)
		{
			await AdminServiceUtils.ValidateQuestion(request);
			var question = await _db.CustomQuestions.GetItem(id);
			if (question == null) throw new CustomException(ErrorStatusEnums.QuestionNotFound);
			var updatedQuestion = mapper.CustomQuestionRequestToCustomQuestion(request);
			updatedQuestion = AdminServiceUtils.ConfigureUpdatedQuestion(updatedQuestion, question);
			
			if (await _db.CustomQuestions.UpsertItem(updatedQuestion))
			{
				return;
			}
			throw new CustomException(ErrorStatusEnums.QuestionUpdateFailed);
		}

		public async Task<CustomQuestionResponse> GetCustomQuestion(string id)
		{
			var question = await _db.CustomQuestions.GetItem(id);
			if (question == null) throw new CustomException(ErrorStatusEnums.QuestionNotFound);
			var response = mapper.CustomQuestionToCustomQuestionResponse(question);
			return response;
		}
		public async Task DeleteCustomQuestion(string id)
		{
			if (await _db.CustomQuestions.DeleteOneItem(id))
			{
				return;
			}
			throw new CustomException(ErrorStatusEnums.QuestionDeleteFailed);

		}

		public async Task<List<CustomQuestion>> GetAllQuestionsForFormConfig(string formConfigId)
		{
			var items = await _db.CustomQuestions.GetItemCategory(formConfigId, "FormConfigId");

			return items;
		}
	}
}
