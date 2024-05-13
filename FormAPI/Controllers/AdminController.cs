﻿using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Infrastructure.Data;
using FormAPI.Models.Helpers;
using FormAPI.Models.Requests;
using FormAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace FormAPI.Controllers
{

	public class AdminController : BaseApiController
	{
		private readonly ApplicationDataContext _db;
		private readonly MapperProfiles mapper = new();
		private readonly IAdminService _adminService;


		public AdminController(ApplicationDataContext db, IAdminService adminService)
		{
			_db = db ?? throw new ArgumentNullException("Didn't work");
			_adminService = adminService;
		}

		[HttpGet("create-form-configuration")]
		public async Task<ActionResult> GetFormSchema()
		{
			return Ok(new FormSchemaResponse());
		}

		[HttpPost("create-form-configuration")]
		public async Task<ActionResult> CreateForm([FromBody] CreateFormConfigurationRequest properties)
		{
			await _adminService.CreateForm(properties);

			return Ok();
		}


		[HttpGet("update-form-config/{id}")]
		public async Task<ActionResult> GetFormConfig(string id)
		{
			var res = await _db.FormProperties.GetItem(id);

			return Ok(res);
		}

		[HttpPost("update-form-config/{id}")]
		public async Task<ActionResult> UpdateForm([FromBody] UpdateFormConfigurationRequest request, string id)
		{
			await _adminService.UpdateForm(request, id);
			return Ok();
		}


		[HttpGet("get-configurations")]
		public async Task<ActionResult> GetConfigurations()
		{
			return Ok(new ConfigurationsResponse());
		}
	}
}
