﻿
namespace Web.Controllers
{
    using System.Web.Mvc;
    using System;
    using BL.Providers;
    using Models;
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InitiativeList()
        {
            var provider = new InitiativeProvider();
            var model = new InitiativesModel
            {
                Initiatives = provider.GetAllInitiatives()
            };

            return View(model);
        }

        public ActionResult Initiative(Guid initiativeId)
        {
            var provider = new InitiativeProvider();

            var intiative = provider.Get(initiativeId);
            var challenges = provider.GetAllChallenges(initiativeId);

            if (intiative == null)
            {
                return View(new InitiativeModel());
            }
            
            var model = new InitiativeModel
            {
                Title = intiative.Title,
                Description = intiative.Description,
                Challenges = challenges
            };

            return View(model);
        }
    }
}