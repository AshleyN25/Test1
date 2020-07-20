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
    public class TritonExpressWaybillsController : Controller
    {
        private readonly TritonExpressContext _context;

        public TritonExpressWaybillsController(TritonExpressContext context)
        {
            _context = context;
        }

        // GET: TritonExpressWaybills
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var waybill = from s in _context.TritonExpressWaybill
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                waybill = waybill.Where(s => s.RecipientName.Contains(searchString)
                                       || s.Address.Contains(searchString)
                                       || s.Cell.Contains(searchString)
                                       || s.WayBillInfo.Contains(searchString)
                                       || s.WayBillweight.Contains(searchString)
                                       || s.NumberOfParcels.Contains(searchString));
            }
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

        // GET: TritonExpressWaybills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonExpressWaybill = await _context.TritonExpressWaybill
                .FirstOrDefaultAsync(m => m.wayBillID == id);
            if (tritonExpressWaybill == null)
            {
                return NotFound();
            }

            return View(tritonExpressWaybill);
        }

        // GET: TritonExpressWaybills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TritonExpressWaybills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("wayBillID,RecipientName,Address,Cell,Date,WayBillInfo,WayBillweight,NumberOfParcels")] TritonExpressWaybill tritonExpressWaybill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tritonExpressWaybill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tritonExpressWaybill);
        }

        // GET: TritonExpressWaybills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonExpressWaybill = await _context.TritonExpressWaybill.FindAsync(id);
            if (tritonExpressWaybill == null)
            {
                return NotFound();
            }
            return View(tritonExpressWaybill);
        }

        // POST: TritonExpressWaybills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("wayBillID,RecipientName,Address,Cell,Date,WayBillInfo,WayBillweight,NumberOfParcels")] TritonExpressWaybill tritonExpressWaybill)
        {
            if (id != tritonExpressWaybill.wayBillID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tritonExpressWaybill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TritonExpressWaybillExists(tritonExpressWaybill.wayBillID))
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
            return View(tritonExpressWaybill);
        }

        // GET: TritonExpressWaybills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tritonExpressWaybill = await _context.TritonExpressWaybill
                .FirstOrDefaultAsync(m => m.wayBillID == id);
            if (tritonExpressWaybill == null)
            {
                return NotFound();
            }

            return View(tritonExpressWaybill);
        }

        // POST: TritonExpressWaybills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tritonExpressWaybill = await _context.TritonExpressWaybill.FindAsync(id);
            _context.TritonExpressWaybill.Remove(tritonExpressWaybill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TritonExpressWaybillExists(int id)
        {
            return _context.TritonExpressWaybill.Any(e => e.wayBillID == id);
        }
    }
}
