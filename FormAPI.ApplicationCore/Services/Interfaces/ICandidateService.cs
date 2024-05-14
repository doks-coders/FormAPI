using FormAPI.Models.Requests;
using FormAPI.Models.Responses;

namespace FormAPI.ApplicationCore.Services.Interfaces
{
	public interface ICandidateService
	{
		Task<FormConfigurationsResponse> GetFormConfiguration(string id);

		Task SubmitForm(CreateCandidateFormRequest request, string id);
	}
}
