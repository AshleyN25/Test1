using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TritonExpress.Models;

namespace TritonExpress.Controllers
{
    public class TritonModelsController : Controller
    {
        private readonly TritonExpressContext _context;

        public TritonModelsController(TritonExpressContext context)
        {
            _context = context;
        }

        // GET: TritonModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.TritonModel.ToListAsync());
        }

        // GET: TritonModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonModel = await _context.TritonModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tritonModel == null)
            {
                return NotFound();
            }

            return View(tritonModel);
        }

        // GET: TritonModels/Create
        public IActionResult Create()
        {
            TritonModel model = new TritonModel();
            model.branch = "Select";
            return View(model);
        }

        // POST: TritonModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,branch,vehicleyear,vehiclemodel,vehiclemake,vehiclereg")] TritonModel tritonModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tritonModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tritonModel);
        }

        // GET: TritonModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonModel = await _context.TritonModel.FindAsync(id);
            if (tritonModel == null)
            {
                return NotFound();
            }

            tritonModel.branch = "Select";
            return View(tritonModel);
        }

        // POST: TritonModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,branch,vehicleyear,vehiclemodel,vehiclemake,vehiclereg")] TritonModel tritonModel)
        {
            if (id != tritonModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tritonModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TritonModelExists(tritonModel.ID))
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
            return View(tritonModel);
        }

        // GET: TritonModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonModel = await _context.TritonModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tritonModel == null)
            {
                return NotFound();
            }

            return View(tritonModel);
        }

        // POST: TritonModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tritonModel = await _context.TritonModel.FindAsync(id);
            _context.TritonModel.Remove(tritonModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TritonModelExists(int id)
        {
            return _context.TritonModel.Any(e => e.ID == id);
        }
    }
}
