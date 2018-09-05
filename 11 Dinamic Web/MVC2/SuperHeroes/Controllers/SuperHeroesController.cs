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
    public class SuperHeroesController : Controller
    {
        private IRepository<SuperHero> _repository;

        public SuperHeroesController(IRepository<SuperHero> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_repository.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                var model = id == null
                    ? new SuperHero()
                    : _repository.Get((int)id);

                return View(model);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(SuperHero model)
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

                // this is not good: every time the user refresh the List,
                // this POST request is executed and a new SuperHero is inserted.
                // return View(nameof(List), _repository.GetAll());

                // It's better to redirect to the correct action in GET:
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
                return RedirectToAction(nameof(List));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}