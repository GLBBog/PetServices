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
    public class PetSizesController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/PetSizes
        public IQueryable<PetSize> GetPetSizes()
        {
            return db.PetSizes;
        }

        // GET api/PetSizes/5
        [ResponseType(typeof(PetSize))]
        public IHttpActionResult GetPetSize(int id)
        {
            PetSize petsize = db.PetSizes.Find(id);
            if (petsize == null)
            {
                return NotFound();
            }

            return Ok(petsize);
        }

        // PUT api/PetSizes/5
        public IHttpActionResult PutPetSize(int id, PetSize petsize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != petsize.Id)
            {
                return BadRequest();
            }

            db.Entry(petsize).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetSizeExists(id))
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

        // POST api/PetSizes
        [ResponseType(typeof(PetSize))]
        public IHttpActionResult PostPetSize(PetSize petsize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetSizes.Add(petsize);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = petsize.Id }, petsize);
        }

        // DELETE api/PetSizes/5
        [ResponseType(typeof(PetSize))]
        public IHttpActionResult DeletePetSize(int id)
        {
            PetSize petsize = db.PetSizes.Find(id);
            if (petsize == null)
            {
                return NotFound();
            }

            db.PetSizes.Remove(petsize);
            db.SaveChanges();

            return Ok(petsize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetSizeExists(int id)
        {
            return db.PetSizes.Count(e => e.Id == id) > 0;
        }
    }
}