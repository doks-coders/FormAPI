using FormAPI.Models.Requests;
using FormAPI.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.ApplicationCore.Services.Interfaces
{
	public interface ICandidateService
	{
		Task<FormConfigurationsResponse> GetFormConfiguration(string id);

		Task SubmitForm(CreateCandidateFormRequest request, string id);
	}
}
