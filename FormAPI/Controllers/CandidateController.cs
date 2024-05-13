using FormAPI.ApplicationCore.Services.Interfaces;
using FormAPI.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

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
		[HttpGet("{id}")]
		public async Task<ActionResult> Index(string id)
		{
			var res = await _candidateService.GetFormConfiguration(id);
			return Ok(res);
		}

		/// <summary>
		/// This method creates an endpoint used that saves candidates form
		/// </summary>
		/// <returns></returns>
		[HttpPost("{id}")]
		public async Task<ActionResult> Index([FromBody] CreateCandidateFormRequest request, string id)
		{
			await _candidateService.SubmitForm(request, id);
			return Ok();
		}
	}
}
