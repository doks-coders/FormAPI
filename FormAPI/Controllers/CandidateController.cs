using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FormAPI.Controllers
{
	public class CandidateController : BaseApiController
	{
		private readonly ICandidateService _candidateService;

		public CandidateController(ICandidateService candidateService)
		{
			_candidateService = candidateService;
		}

		/// <summary>
		/// This method creates an endpoint that gets the saved form configuration information
		/// for the frontend developer to design the ui
		/// </summary>
		/// <returns></returns>
		[HttpGet("{formId}")]
		public async Task<ActionResult> Index(string formId)
		{
			var res = await _candidateService.GetFormConfiguration(formId);
			return Ok(res);
		}

		/// <summary>
		/// This method creates an endpoint that saves candidates form
		/// </summary>
		/// <returns></returns>
		[HttpPost("{formId}")]
		public async Task<ActionResult> Index([FromBody] CreateCandidateFormRequest request, string formId)
		{
			await _candidateService.SubmitForm(request, formId);
			return Ok();
		}
	}
}
