using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes.DataAccess;
using SuperHeroes.Infrastructure;
using SuperHeroes.Models;

namespace SuperHeroes.Controllers
{
    public class VillainsController : Controller
    {
        private IRepository<Villain> _repository;
        private IRepository<SuperHero> _superHeroRepository;

        public VillainsController(
            IRepository<Villain> repository,
            IRepository<SuperHero> superHeroRepository)
        {
            _repository = repository;
            _superHeroRepository = superHeroRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            ViewData["Title"] = "World";
            ViewBag.Subtitle = "Villains";

            return View(_repository.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                var model = id == null
                    ? new Villain()
                    : _repository.Get((int)id);

                return View(model);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(Villain model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (model.Id == 0)
                    _repository.Insert(model);
                else
                    _repository.Update(model);

                return RedirectToAction(nameof(List));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _repository.Get(id);

                return View(model);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                _repository.Delete(id);

                TempData["Message"] = "Villain successfully deleted!";

                return RedirectToAction(nameof(List));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Play()
        {
            var sh = _superHeroRepository.GetAll().First();
            var v = _repository.GetAll().First();
            v.Nemesis = sh;
            _repository.Update(v);



            return RedirectToAction(nameof(List));
        }
    }
}