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
    public class PetActivitiesController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/PetActivities
        public IQueryable<PetActivity> GetPetActivities()
        {
            return db.PetActivities;
        }

        // GET api/PetActivities/5
        [ResponseType(typeof(PetActivity))]
        public IHttpActionResult GetPetActivity(int id)
        {
            PetActivity petactivity = db.PetActivities.Find(id);
            if (petactivity == null)
            {
                return NotFound();
            }

            return Ok(petactivity);
        }

        // PUT api/PetActivities/5
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

        // POST api/PetActivities
        [ResponseType(typeof(PetActivity))]
        public IHttpActionResult PostPetActivity(PetActivity petactivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetActivities.Add(petactivity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = petactivity.Id }, petactivity);
        }

        // DELETE api/PetActivities/5
        [ResponseType(typeof(PetActivity))]
        public IHttpActionResult DeletePetActivity(int id)
        {
            PetActivity petactivity = db.PetActivities.Find(id);
            if (petactivity == null)
            {
                return NotFound();
            }

            db.PetActivities.Remove(petactivity);
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
            return db.PetActivities.Count(e => e.Id == id) > 0;
        }
    }
}