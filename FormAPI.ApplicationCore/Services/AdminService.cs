using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Infrastructure.Data;
using FormAPI.Models.Entities;
using FormAPI.Models.Extensions;
using FormAPI.Models.Helpers;
using FormAPI.Models.Requests;
using Microsoft.Azure.Cosmos.Core;
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

		/// <summary>
		/// This is method creates the a form configuration that will be used to display information to the user
		/// </summary>
		/// <param name="properties"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public async Task CreateForm(CreateFormConfigurationRequest properties)
		{
			var item = mapper.CreateFormConfigurationRequestToFormConfiguration(properties);
			item = item.SetDefaultIfEmpty();
			item = item.SetMandatoryProperties();
			item.id = Guid.NewGuid().ToString();
			if(await _db.FormConfigurations.UpsertItem(item))
			{
				return;
			}
			throw new Exception("Did not Save Successfully");
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
			if (res == null) throw new Exception("Not Found");
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
			if (item == null) throw new Exception("Not Found");
			var updatedProperty = mapper.UpdateFormConfigurationRequestToFormConfiguration(request);
			updatedProperty = updatedProperty.GetIdandPartitionKey(item);
			updatedProperty = updatedProperty.SetDefaultIfEmpty();
			updatedProperty = updatedProperty.SetMandatoryProperties();
			if(await _db.FormConfigurations.UpsertItem(updatedProperty))
			{
				return;
			}
			throw new Exception("Did not Save Successfully");

		}
	}
}
