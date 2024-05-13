﻿using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Infrastructure.Data;
using FormAPI.Models.Entities;
using FormAPI.Models.Helpers;
using FormAPI.Models.Requests;
using FormAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace FormAPI.Controllers
{

	public class AdminController : BaseApiController
	{
	
		private readonly IAdminService _adminService;


		public AdminController( IAdminService adminService)
		{
			_adminService = adminService;
		}

		/// <summary>
		/// This method creates an endpoint used for retrieving the intial form schema. 
		/// This will assist the front end developer to design the ui
		/// </summary>
		/// <returns></returns>
		[HttpGet("create-form-configuration")]
		public async Task<ActionResult> GetFormSchema()
		{
			return Ok(new FormSchemaResponse());
		}

		/// <summary>
		/// This method creates an endpoint used for creating form configuration information
		/// </summary>
		/// <returns></returns>
		[HttpPost("create-form-configuration")]
		public async Task<ActionResult> CreateForm([FromBody] CreateFormConfigurationRequest properties)
		{
			await _adminService.CreateForm(properties);

			return Ok("Item Created Successfully");
		}

		/// <summary>
		/// This method creates an endpoint used for gets the saved form configuration information
		/// </summary>
		/// <returns></returns>
		[HttpGet("update-form-config/{id}")]
		public async Task<ActionResult> GetFormConfig(string id)
		{
			var res = await _adminService.GetFormConfig(id);

			return Ok(res);
		}

		/// <summary>
		/// This method creates an endpoint that updates the saved form configuration information
		/// </summary>
		/// <returns></returns>
		[HttpPut("update-form-config/{id}")]
		public async Task<ActionResult> UpdateForm([FromBody] UpdateFormConfigurationRequest request, string id)
		{
			await _adminService.UpdateForm(request, id);
			return Ok("Item Updated Successfully");
		}


		[HttpGet("get-form-questions/{questionId}")]
		public async Task<ActionResult> GetCustomQuestionsForFormConfig(string questionId)
		{
			var res = await _adminService.GetAllQuestionsForFormConfig(questionId);
			return Ok(res);
		}

		[HttpPost("create-question/{formId}")]
		public async Task<ActionResult> CreateCustomQuestion([FromBody] CustomQuestion request, string formId)
		{
			await _adminService.CreateCustomQuestion(request, formId);
			return Ok("Item Created Successfully");
		}

		[HttpPost("update-question/{questionId}")]
		public async Task<ActionResult> UpdateCustomQuestion([FromBody] CustomQuestion request, string questionId)
		{
			await _adminService.UpdateCustomQuestion(request, questionId);
			return Ok("Item Updated Successfully");
		}

		[HttpDelete("delete-question/{questionId}")]
		public async Task<ActionResult> DeleteCustomQuestion( string questionId)
		{
			await _adminService.DeleteCustomQuestion(questionId);
			return Ok("Item Deleted Successfully");
		}



	}
}
