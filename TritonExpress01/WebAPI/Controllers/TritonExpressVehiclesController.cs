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
    public class TritonExpressVehiclesController : ApiController
    {
        private TritonExpressEntities db = new TritonExpressEntities();

        // GET: api/TritonExpressVehicles
        public IQueryable<TritonExpressVehicle> GetTritonExpressVehicles()
        {
            return db.TritonExpressVehicles;
        }

        // GET: api/TritonExpressVehicles/5
        [ResponseType(typeof(TritonExpressVehicle))]
        public IHttpActionResult GetTritonExpressVehicle(int id)
        {
            TritonExpressVehicle tritonExpressVehicle = db.TritonExpressVehicles.Find(id);
            if (tritonExpressVehicle == null)
            {
                return NotFound();
            }

            return Ok(tritonExpressVehicle);
        }

        // PUT: api/TritonExpressVehicles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTritonExpressVehicle(int id, TritonExpressVehicle tritonExpressVehicle)
        {
            if (id != tritonExpressVehicle.ID)
            {
                return BadRequest();
            }

            db.Entry(tritonExpressVehicle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TritonExpressVehicleExists(id))
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

        // POST: api/TritonExpressVehicles
        [ResponseType(typeof(TritonExpressVehicle))]
        public IHttpActionResult PostTritonExpressVehicle(TritonExpressVehicle tritonExpressVehicle)
        {
            db.TritonExpressVehicles.Add(tritonExpressVehicle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tritonExpressVehicle.ID }, tritonExpressVehicle);
        }

        // DELETE: api/TritonExpressVehicles/5
        [ResponseType(typeof(TritonExpressVehicle))]
        public IHttpActionResult DeleteTritonExpressVehicle(int id)
        {
            TritonExpressVehicle tritonExpressVehicle = db.TritonExpressVehicles.Find(id);
            if (tritonExpressVehicle == null)
            {
                return NotFound();
            }

            db.TritonExpressVehicles.Remove(tritonExpressVehicle);
            db.SaveChanges();

            return Ok(tritonExpressVehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TritonExpressVehicleExists(int id)
        {
            return db.TritonExpressVehicles.Count(e => e.ID == id) > 0;
        }
    }
}