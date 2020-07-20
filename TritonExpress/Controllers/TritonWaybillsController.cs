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
    public class TritonWaybillsController : Controller
    {
        private readonly TritonExpressContext _context;

        public TritonWaybillsController(TritonExpressContext context)
        {
            _context = context;
        }

        // GET: TritonWaybills
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var waybill = from s in _context.TritonExpressWaybill
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    waybill = waybill.OrderByDescending(s => s.RecipientName);
                    break;
                case "Date":
                    waybill = waybill.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    waybill = waybill.OrderByDescending(s => s.Date);
                    break;
                default:
                    waybill = waybill.OrderBy(s => s.RecipientName);
                    break;
            }
            return View(await waybill.AsNoTracking().ToListAsync());
        }

        // GET: TritonWaybills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonWaybill = await _context.TritonWaybill
                .FirstOrDefaultAsync(m => m.wayBillID == id);
            if (tritonWaybill == null)
            {
                return NotFound();
            }

            return View(tritonWaybill);
        }

        // GET: TritonWaybills/Create
        public IActionResult Create()
        {
            List<TritonModel> tritonvehList = new List<TritonModel>();

            tritonvehList = (from vehicle in _context.TritonModel
                             select vehicle).ToList();
            tritonvehList.Insert(0, new TritonModel { ID = 0, vehiclereg = "Select" });
            ViewBag.ListOfVehicle = tritonvehList;
            return View();
        }

        // POST: TritonWaybills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("wayBillID,VehicleID,WayBillInfo,WauBillweight,NumberOfParcels")] TritonWaybill tritonWaybill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tritonWaybill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tritonWaybill);
        }

        // GET: TritonWaybills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonWaybill = await _context.TritonWaybill.FindAsync(id);
            if (tritonWaybill == null)
            {
                return NotFound();
            }
            List<TritonModel> tritonvehList = new List<TritonModel>();

            tritonvehList = (from vehicle in _context.TritonModel
                             select vehicle).ToList();
            tritonvehList.Insert(0, new TritonModel { ID = 0, vehiclereg = "Select" });
            ViewBag.ListOfVehicleEdit = tritonvehList;
            return View(tritonWaybill);
        }

        // POST: TritonWaybills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("wayBillID,VehicleID,WayBillInfo,WauBillweight,NumberOfParcels")] TritonWaybill tritonWaybill)
        {
            if (id != tritonWaybill.wayBillID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tritonWaybill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TritonWaybillExists(tritonWaybill.wayBillID))
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
            return View(tritonWaybill);
        }

        // GET: TritonWaybills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonWaybill = await _context.TritonWaybill
                .FirstOrDefaultAsync(m => m.wayBillID == id);
            if (tritonWaybill == null)
            {
                return NotFound();
            }

            return View(tritonWaybill);
        }

        // POST: TritonWaybills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tritonWaybill = await _context.TritonWaybill.FindAsync(id);
            _context.TritonWaybill.Remove(tritonWaybill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TritonWaybillExists(int id)
        {
            return _context.TritonWaybill.Any(e => e.wayBillID == id);
        }
    }
}
