using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Infrastructure.Data;
using FormAPI.Models.Extensions;
using FormAPI.Models.Helpers;
using FormAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public async Task CreateForm(CreateFormConfigurationRequest properties)
		{
			var item = mapper.CreateFormConfigurationRequestToFormConfiguration(properties);

			item = item.SetMandatoryProperties();
			item.id = Guid.NewGuid().ToString();
			item.partitionKeyPath = "MyTestPkValue";
			var isSuccess = await _db.FormConfigurations.UpsertItem(item);
		}

		public async Task UpdateForm(UpdateFormConfigurationRequest request, string id)
		{
			var item = await _db.FormConfigurations.GetItem(id);
			if (item == null) throw new Exception("Not Found");
			var updatedProperty = mapper.UpdateFormConfigurationRequestToFormConfiguration(request);
			updatedProperty = updatedProperty.GetIdandPartitionKey(item);
			updatedProperty = updatedProperty.SetMandatoryProperties();
			await _db.FormConfigurations.UpsertItem(updatedProperty);
		}
	}
}
