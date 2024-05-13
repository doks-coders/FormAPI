using Microsoft.AspNetCore.Mvc;

namespace FormAPI.Controllers
{
	public class CandidateController : BaseApiController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
