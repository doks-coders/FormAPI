using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Infrastructure.Data;
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

		public async Task<FormConfigurationsResponse> GetFormConfiguration(string id)
		{
			var item = await _db.FormConfigurations.GetItem(id);
			if (item == null) throw new Exception("Specific Form Not Found");
			var res = mapper.FormConfigurationToFormConfigurationResponse(item);
			return res;
		}

		public async Task SubmitForm(CreateCandidateFormRequest request, string id)
		{
			var entity = mapper.CandidateFormRequestToCandidateForm(request);
			entity.FormConfigurationId = id;
			entity.id = Guid.NewGuid().ToString();
			if(await _db.CandidateForms.UpsertItem(entity))
			{
				return;
			}
			throw new Exception("Did not save Successfully");
		}
	}
}
