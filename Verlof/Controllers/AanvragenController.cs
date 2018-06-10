using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Verlof.Data;
using Verlof.Repositories;

namespace Verlof.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class AanvragenController : Controller
    {
        private AanvragenRepository AanvragenRepo;

        public AanvragenController(AanvragenRepository aanvragenRepo)
        {
            AanvragenRepo = aanvragenRepo;
        }
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Aanvragen aanvragen)
        {
            AanvragenRepo.addAanvraag(aanvragen);
            return RedirectToAction("");
        }

        [AllowAnonymous]
        [Route("")]
        public IActionResult Index()
        {
            return View(AanvragenRepo.GetAlleAanvragen());


        }
        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            Aanvragen aanvragen = AanvragenRepo.getAanvraag(id);

            return View(aanvragen);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Aanvragen aanvragen, int id)
        {
            AanvragenRepo.updateAanvraag(aanvragen,id);
            return RedirectToAction("");
        }
    }
}