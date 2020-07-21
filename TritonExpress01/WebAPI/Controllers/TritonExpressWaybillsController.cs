using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TritonExpressWaybillsController : ApiController
    {
        private TritonExpressEntities db = new TritonExpressEntities();

        // GET: api/TritonExpressWaybills
        public IQueryable<TritonExpressWaybill> GetTritonExpressWaybills()
        {
            return db.TritonExpressWaybills;
        }

        // GET: api/TritonExpressWaybills/5
        [ResponseType(typeof(TritonExpressWaybill))]
        public IHttpActionResult GetTritonExpressWaybill(int id)
        {
            TritonExpressWaybill tritonExpressWaybill = db.TritonExpressWaybills.Find(id);
            if (tritonExpressWaybill == null)
            {
                return NotFound();
            }

            return Ok(tritonExpressWaybill);
        }

        // PUT: api/TritonExpressWaybills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTritonExpressWaybill(int id, TritonExpressWaybill tritonExpressWaybill)
        {
            if (id != tritonExpressWaybill.wayBillID)
            {
                return BadRequest();
            }

            db.Entry(tritonExpressWaybill).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TritonExpressWaybillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TritonExpressWaybills
        [ResponseType(typeof(TritonExpressWaybill))]
        public IHttpActionResult PostTritonExpressWaybill(TritonExpressWaybill tritonExpressWaybill)
        {
            db.TritonExpressWaybills.Add(tritonExpressWaybill);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tritonExpressWaybill.wayBillID }, tritonExpressWaybill);
        }

        // DELETE: api/TritonExpressWaybills/5
        [ResponseType(typeof(TritonExpressWaybill))]
        public IHttpActionResult DeleteTritonExpressWaybill(int id)
        {
            TritonExpressWaybill tritonExpressWaybill = db.TritonExpressWaybills.Find(id);
            if (tritonExpressWaybill == null)
            {
                return NotFound();
            }

            db.TritonExpressWaybills.Remove(tritonExpressWaybill);
            db.SaveChanges();

            return Ok(tritonExpressWaybill);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TritonExpressWaybillExists(int id)
        {
            return db.TritonExpressWaybills.Count(e => e.wayBillID == id) > 0;
        }
    }
}