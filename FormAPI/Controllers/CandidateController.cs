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

		[HttpGet("{id}")]
		public async Task<ActionResult> Index(string id)
		{
			var res = await _candidateService.GetFormConfiguration(id);
			return Ok(res);
		}

		[HttpPost("{id}")]
		public async Task<ActionResult> Index([FromBody] CreateCandidateFormRequest request, string id)
		{
			await _candidateService.SubmitForm(request, id);
			return Ok();
		}
	}
}
