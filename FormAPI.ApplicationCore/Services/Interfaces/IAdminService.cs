﻿using FormAPI.Models.Entities;
using FormAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAPI.ApplicationCore.Services.Interfaces
{
	public interface IAdminService
	{
		Task CreateForm(CreateFormConfigurationRequest properties);
		Task UpdateForm(UpdateFormConfigurationRequest request, string id);
		Task <FormConfiguration> GetFormConfig(string id);

	}
}
