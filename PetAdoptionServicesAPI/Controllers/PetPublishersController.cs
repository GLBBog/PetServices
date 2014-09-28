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
    public class PetPublishersController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/PetPublishers
        public IQueryable<PetPublisher> GetPetPublishers()
        {
            return db.PetPublishers;
        }

        // GET api/PetPublishers/5
        [ResponseType(typeof(PetPublisher))]
        public IHttpActionResult GetPetPublisher(long id)
        {
            PetPublisher petpublisher = db.PetPublishers.Find(id);
            if (petpublisher == null)
            {
                return NotFound();
            }

            return Ok(petpublisher);
        }

        // PUT api/PetPublishers/5
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

        // POST api/PetPublishers
        [ResponseType(typeof(PetPublisher))]
        public IHttpActionResult PostPetPublisher(PetPublisher petpublisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetPublishers.Add(petpublisher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = petpublisher.Id }, petpublisher);
        }

        // DELETE api/PetPublishers/5
        [ResponseType(typeof(PetPublisher))]
        public IHttpActionResult DeletePetPublisher(long id)
        {
            PetPublisher petpublisher = db.PetPublishers.Find(id);
            if (petpublisher == null)
            {
                return NotFound();
            }

            db.PetPublishers.Remove(petpublisher);
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
            return db.PetPublishers.Count(e => e.Id == id) > 0;
        }
    }
}