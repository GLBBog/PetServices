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
using PetAdoptionServicesAPI.Models;

namespace PetAdoptionServicesAPI.Controllers
{
    public class PetActivityController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/PetActivity
        public IQueryable<PetActivity> GetPetActivity()
        {
            return db.PetActivity;
        }

        // GET api/PetActivity/5
        [ResponseType(typeof(PetActivity))]
        public IHttpActionResult GetPetActivity(int id)
        {
            PetActivity petactivity = db.PetActivity.Find(id);
            if (petactivity == null)
            {
                return NotFound();
            }

            return Ok(petactivity);
        }

        // PUT api/PetActivity/5
        public IHttpActionResult PutPetActivity(int id, PetActivity petactivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petactivity.Id)
            {
                return BadRequest();
            }

            db.Entry(petactivity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetActivityExists(id))
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

        // POST api/PetActivity
        [ResponseType(typeof(PetActivity))]
        public IHttpActionResult PostPetActivity(PetActivity petactivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetActivity.Add(petactivity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = petactivity.Id }, petactivity);
        }

        // DELETE api/PetActivity/5
        [ResponseType(typeof(PetActivity))]
        public IHttpActionResult DeletePetActivity(int id)
        {
            PetActivity petactivity = db.PetActivity.Find(id);
            if (petactivity == null)
            {
                return NotFound();
            }

            db.PetActivity.Remove(petactivity);
            db.SaveChanges();

            return Ok(petactivity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetActivityExists(int id)
        {
            return db.PetActivity.Count(e => e.Id == id) > 0;
        }
    }
}