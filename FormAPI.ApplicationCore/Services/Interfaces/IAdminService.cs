using FormAPI.Models.Entities;
using FormAPI.Models.Requests;
using FormAPI.Models.Responses;

namespace FormAPI.ApplicationCore.Services.Interfaces
{
	public interface IAdminService
	{
		Task<string> CreateForm(CreateFormConfigurationRequest properties);
		Task UpdateForm(UpdateFormConfigurationRequest request, string id);
		Task<FormConfiguration> GetFormConfig(string id);
		Task<CustomQuestionResponse> GetCustomQuestion(string id);
		Task<string> CreateCustomQuestion(CustomQuestionRequest request, string formConfigId);
		Task UpdateCustomQuestion(CustomQuestionRequest request, string id);
		Task DeleteCustomQuestion(string id);
		Task<List<CustomQuestion>> GetAllQuestionsForFormConfig(string formConfigId);

	}
}
