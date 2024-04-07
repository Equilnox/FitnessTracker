﻿using FitnessTracker.Core.Contracts;
using FitnessTracker.Core.Models.Athlete;
using FitnessTracker.Core.Models.Gym;
using FitnessTracker.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [Authorize]
    public class AthleteController : Controller
    {
        private readonly IAthleteService service;
        private readonly IGymService gymService;

        public AthleteController(IAthleteService _service, IGymService _gymService)
        {
            service = _service;
            gymService = _gymService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await service.GetAthlete(User.Id());

            if (model == null)
            {
                return RedirectToAction(nameof(CreateAthlete));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAthlete()
        {
            AthleteCreateFormModel model = new AthleteCreateFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAthlete(AthleteCreateFormModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                model = new AthleteCreateFormModel();

                return View(model);
            }

            await service.AddNewAthleteAsync(model, userId);

            var personalGym = new GymFromModel()
            {
                OwnerId = userId
            };
            
            await gymService.AddPersonalGymAsync(personalGym);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await service.FindByIdAsync(id);

            if(model == null)
            {
                return BadRequest();
            }

            string userId = User.Id();

            bool userIsAthlete = await service.CheckUserId(userId, id);

            if (userIsAthlete == false)
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AthleteDetailsEditFormModel athleteDetails)
        {
            if(!ModelState.IsValid)
            {
                AthleteDetailsEditFormModel model = new AthleteDetailsEditFormModel() 
                {
                    Id = athleteDetails.Id,
                    FirstName = athleteDetails.FirstName,
                    LastName = athleteDetails.LastName,
                    Age = athleteDetails.Age,
                    Weight = athleteDetails.Weight,
                    Height = athleteDetails.Height
                };

                return View(model);
            }

            await service.EditDetailsAsync(athleteDetails);
            await service.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
