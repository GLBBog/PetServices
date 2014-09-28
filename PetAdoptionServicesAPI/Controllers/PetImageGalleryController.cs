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
    public class PetImageGalleryController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/PetImageGallery
        public IQueryable<PetImageGallery> GetPetImageGalleries()
        {
            return db.PetImageGalleries;
        }

        // GET api/PetImageGallery/5
        [ResponseType(typeof(PetImageGallery))]
        public IHttpActionResult GetPetImageGallery(long id)
        {
            PetImageGallery petimagegallery = db.PetImageGalleries.Find(id);
            if (petimagegallery == null)
            {
                return NotFound();
            }

            return Ok(petimagegallery);
        }

        // PUT api/PetImageGallery/5
        public IHttpActionResult PutPetImageGallery(long id, PetImageGallery petimagegallery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petimagegallery.Id)
            {
                return BadRequest();
            }

            db.Entry(petimagegallery).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetImageGalleryExists(id))
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

        // POST api/PetImageGallery
        [ResponseType(typeof(PetImageGallery))]
        public IHttpActionResult PostPetImageGallery(PetImageGallery petimagegallery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetImageGalleries.Add(petimagegallery);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = petimagegallery.Id }, petimagegallery);
        }

        // DELETE api/PetImageGallery/5
        [ResponseType(typeof(PetImageGallery))]
        public IHttpActionResult DeletePetImageGallery(long id)
        {
            PetImageGallery petimagegallery = db.PetImageGalleries.Find(id);
            if (petimagegallery == null)
            {
                return NotFound();
            }

            db.PetImageGalleries.Remove(petimagegallery);
            db.SaveChanges();

            return Ok(petimagegallery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetImageGalleryExists(long id)
        {
            return db.PetImageGalleries.Count(e => e.Id == id) > 0;
        }
    }
}