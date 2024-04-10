using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessTracker.Core.Constants.RoleConstants;

namespace FitnessTracker.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = AdministratorRole)]
	public class AdminBaseController : Controller
	{
	}
}
