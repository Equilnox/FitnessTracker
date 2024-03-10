﻿using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Exercise;
using FitnessTracker.Core.Models.Gym;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
	public class GymController : Controller
	{
		private readonly IGymService service;

		public GymController(IGymService _service)
		{
			service = _service;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var model = await service.GetAllAsync();

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var model = await service.GetGymAsync(id);

			return View(model);
		}

		[HttpGet]
		public IActionResult Renew(int athleteId, int gymId)
		{
			var model = new GymMembershipRenewFormModel()
			{
				AthleteId = athleteId,
				GymId = gymId
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Renew(GymMembershipRenewFormModel model)
		{
            if (!ModelState.IsValid)
            {
                model = new GymMembershipRenewFormModel() 
				{ 
					AthleteId = model.AthleteId, 
					GymId = model.GymId 
				};

                return View(model);
            }

			await service.RenewAsync(model);

			return RedirectToAction(nameof(Details), new { id = model.GymId} );
        }
	}
}
