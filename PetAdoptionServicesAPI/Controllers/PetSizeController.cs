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
    public class PetSizeController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/PetSize
        public IQueryable<PetSize> GetPetSize()
        {
            return db.PetSize;
        }

        // GET api/PetSize/5
        [ResponseType(typeof(PetSize))]
        public IHttpActionResult GetPetSize(int id)
        {
            PetSize petsize = db.PetSize.Find(id);
            if (petsize == null)
            {
                return NotFound();
            }

            return Ok(petsize);
        }

        // PUT api/PetSize/5
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

        // POST api/PetSize
        [ResponseType(typeof(PetSize))]
        public IHttpActionResult PostPetSize(PetSize petsize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetSize.Add(petsize);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = petsize.Id }, petsize);
        }

        // DELETE api/PetSize/5
        [ResponseType(typeof(PetSize))]
        public IHttpActionResult DeletePetSize(int id)
        {
            PetSize petsize = db.PetSize.Find(id);
            if (petsize == null)
            {
                return NotFound();
            }

            db.PetSize.Remove(petsize);
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
            return db.PetSize.Count(e => e.Id == id) > 0;
        }
    }
}