using DataAccessLayer.Repository;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Controllers
{
    public class BaseController<T> : Controller where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repo;

        public BaseController(IBaseRepository<T> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _repo.Get(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(T entity)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

      
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _repo.Get(id.Value);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, T entity)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(entity);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_repo.Exists(entity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _repo.Get(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
