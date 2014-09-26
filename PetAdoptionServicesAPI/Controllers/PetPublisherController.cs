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
    public class PetPublisherController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/PetPublisher
        public IQueryable<PetPublisher> GetPetPublisher()
        {
            return db.PetPublisher;
        }

        // GET api/PetPublisher/5
        [ResponseType(typeof(PetPublisher))]
        public IHttpActionResult GetPetPublisher(long id)
        {
            PetPublisher petpublisher = db.PetPublisher.Find(id);
            if (petpublisher == null)
            {
                return NotFound();
            }

            return Ok(petpublisher);
        }

        // PUT api/PetPublisher/5
        public IHttpActionResult PutPetPublisher(long id, PetPublisher petpublisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petpublisher.Id)
            {
                return BadRequest();
            }

            db.Entry(petpublisher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetPublisherExists(id))
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

        // POST api/PetPublisher
        [ResponseType(typeof(PetPublisher))]
        public IHttpActionResult PostPetPublisher(PetPublisher petpublisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetPublisher.Add(petpublisher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = petpublisher.Id }, petpublisher);
        }

        // DELETE api/PetPublisher/5
        [ResponseType(typeof(PetPublisher))]
        public IHttpActionResult DeletePetPublisher(long id)
        {
            PetPublisher petpublisher = db.PetPublisher.Find(id);
            if (petpublisher == null)
            {
                return NotFound();
            }

            db.PetPublisher.Remove(petpublisher);
            db.SaveChanges();

            return Ok(petpublisher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetPublisherExists(long id)
        {
            return db.PetPublisher.Count(e => e.Id == id) > 0;
        }
    }
}