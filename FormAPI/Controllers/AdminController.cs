using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Models.Requests;
using FormAPI.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FormAPI.Controllers
{

	public class AdminController : BaseApiController
	{

		private readonly IAdminService _adminService;


		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		/// <summary>
		/// This method creates an endpoint used for retrieving the initial form schema. 
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
		/// This method creates an endpoint that gets the saved form configuration information
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

		/// <summary>
		/// TThis method creates an endpoint that  gets all questions associated to a form config
		/// </summary>
		/// <param name="formId"></param>
		/// <returns></returns>
		[HttpGet("get-form-questions/{formId}")]
		public async Task<ActionResult> GetCustomQuestionsForFormConfig(string formId)
		{
			var res = await _adminService.GetAllQuestionsForFormConfig(formId);
			return Ok(res);
		}

		/// <summary>
		/// This method creates an endpoint that creates a custom question
		/// </summary>
		/// <param name="request"></param>
		/// <param name="formId"></param>
		/// <returns></returns>
		[HttpPost("create-question/{formId}")]
		public async Task<ActionResult> CreateCustomQuestion([FromBody] CustomQuestionRequest request, string formId)
		{
			await _adminService.CreateCustomQuestion(request, formId);
			return Ok("Item Created Successfully");
		}

		/// <summary>
		/// This method creates an endpoint that updates the custom question
		/// </summary>
		/// <param name="request"></param>
		/// <param name="questionId"></param>
		/// <returns></returns>
		[HttpPut("update-question/{questionId}")]
		public async Task<ActionResult> UpdateCustomQuestion([FromBody] CustomQuestionRequest request, string questionId)
		{
			await _adminService.UpdateCustomQuestion(request, questionId);
			return Ok("Item Updated Successfully");
		}
		/// <summary>
		/// This method creates an endpoint that deletes the custom question
		/// </summary>
		/// <param name="questionId"></param>
		/// <returns></returns>
		[HttpDelete("delete-question/{questionId}")]
		public async Task<ActionResult> DeleteCustomQuestion(string questionId)
		{
			await _adminService.DeleteCustomQuestion(questionId);
			return Ok("Item Deleted Successfully");
		}



	}
}
