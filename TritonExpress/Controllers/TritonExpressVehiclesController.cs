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
    public class TritonExpressVehiclesController : Controller
    {
        private readonly TritonExpressContext _context;

        public TritonExpressVehiclesController(TritonExpressContext context)
        {
            _context = context;
        }

        // GET: TritonExpressVehicles
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var vehicle = from s in _context.TritonExpressVehicle
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicle = vehicle.Where(s => s.vehiclemake.Contains(searchString)
                                       || s.vehiclemodel.Contains(searchString)
                                       || s.vehiclereg.Contains(searchString)
                                       || Convert.ToString(s.vehicleyear).Contains(searchString)
                                       || Convert.ToString(s.wayBillID).Contains(searchString)
                                       || s.branch.Contains(searchString));
            }
            return View(await vehicle.AsNoTracking().ToListAsync());
        }

        // GET: TritonExpressVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonExpressVehicle = await _context.TritonExpressVehicle
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tritonExpressVehicle == null)
            {
                return NotFound();
            }

            return View(tritonExpressVehicle);
        }

        // GET: TritonExpressVehicles/Create
        public IActionResult Create()
        {
            TritonExpressVehicle model = new TritonExpressVehicle();
            model.branch = "Select";

            List<TritonExpressWaybill> tritonwaybillList = new List<TritonExpressWaybill>();

            tritonwaybillList = (from waybill in _context.TritonExpressWaybill
                             select waybill).ToList();
            tritonwaybillList.Insert(0, new TritonExpressWaybill { wayBillID = 0, RecipientName = "Select" });
            ViewBag.ListOfWaybill = tritonwaybillList;

            return View(model);
        }

        // POST: TritonExpressVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,branch,vehicleyear,vehiclemake,vehiclemodel,vehiclereg,wayBillID")] TritonExpressVehicle tritonExpressVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tritonExpressVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tritonExpressVehicle);
        }

        // GET: TritonExpressVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonExpressVehicle = await _context.TritonExpressVehicle.FindAsync(id);
            if (tritonExpressVehicle == null)
            {
                return NotFound();
            }
            tritonExpressVehicle.branch = "Select";
            List<TritonExpressWaybill> tritonwaybillList = new List<TritonExpressWaybill>();

            tritonwaybillList = (from waybill in _context.TritonExpressWaybill
                                 select waybill).ToList();
            tritonwaybillList.Insert(0, new TritonExpressWaybill { wayBillID = 0, RecipientName = "Select" });
            ViewBag.ListOfWaybillEdit = tritonwaybillList;
            return View(tritonExpressVehicle);
        }

        // POST: TritonExpressVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,branch,vehicleyear,vehiclemake,vehiclemodel,vehiclereg,wayBillID")] TritonExpressVehicle tritonExpressVehicle)
        {
            if (id != tritonExpressVehicle.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tritonExpressVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TritonExpressVehicleExists(tritonExpressVehicle.ID))
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
            return View(tritonExpressVehicle);
        }

        // GET: TritonExpressVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonExpressVehicle = await _context.TritonExpressVehicle
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tritonExpressVehicle == null)
            {
                return NotFound();
            }

            return View(tritonExpressVehicle);
        }

        // POST: TritonExpressVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tritonExpressVehicle = await _context.TritonExpressVehicle.FindAsync(id);
            _context.TritonExpressVehicle.Remove(tritonExpressVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TritonExpressVehicleExists(int id)
        {
            return _context.TritonExpressVehicle.Any(e => e.ID == id);
        }

        public ActionResult Changes()
        {
            return RedirectToAction("Index", "TritonExpressWaybills");
        }
    }
}
