using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UI.Web.Data;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    [Authorize]
    public class PinosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Services.IRepositoryGeneric<Pino> repositoryPino;

        public PinosController(Services.IRepositoryGeneric<Pino> repoPino)
        {
            repositoryPino = repoPino;
        }

        // GET: Pinos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await repositoryPino.GetAllAsync();
            return View(applicationDbContext);
        }

        // GET: Pinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pino = await repositoryPino.GetAsync(id.Value);
            if (pino == null)
            {
                return NotFound();
            }

            return View(pino);
        }

        // GET: Pinos/Create
        public IActionResult Create()
        {
            ViewData["PinoId"] = new SelectList(repositoryPino.GetAll(), "PinoId", "Nome");
            return View();
        }

        // POST: Pinos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Pino pino)
        {
            if (ModelState.IsValid)
            {
                await repositoryPino.InsertAsync(pino);
                return RedirectToAction(nameof(Index));
            }
            return View(pino);
        }

        // GET: Pinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pino = await repositoryPino.GetAsync(id.Value);
            if (pino == null)
            {
                return NotFound();
            }
            return View(pino);
        }

        // POST: Pinos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Pino pino)
        {
            if (id != pino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await repositoryPino.UpdateAsync(id, pino);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PinoId"] = new SelectList(repositoryPino.GetAll(), "PinoId", "Nome");
            return View(pino);
        }

        // GET: Pinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pino = await repositoryPino.GetAsync(id);

            if (pino == null)
            {
                return NotFound();
            }

            return View(pino);
        }

        // POST: Pinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repositoryPino.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PinoExists(int id)
        {
            return _context.Pino.Any(e => e.Id == id);
        }
    }
}
