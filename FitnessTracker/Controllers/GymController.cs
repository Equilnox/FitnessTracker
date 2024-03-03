using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
	public class GymController : Controller
	{
		public IActionResult All()
		{
			return View();
		}
	}
}
