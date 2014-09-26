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
    public class PetTypeController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/PetType
        public IQueryable<PetType> GetPetType()
        {
            return db.PetType;
        }

        // GET api/PetType/5
        [ResponseType(typeof(PetType))]
        public IHttpActionResult GetPetType(int id)
        {
            PetType pettype = db.PetType.Find(id);
            if (pettype == null)
            {
                return NotFound();
            }

            return Ok(pettype);
        }

        // PUT api/PetType/5
        public IHttpActionResult PutPetType(int id, PetType pettype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pettype.Id)
            {
                return BadRequest();
            }

            db.Entry(pettype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetTypeExists(id))
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

        // POST api/PetType
        [ResponseType(typeof(PetType))]
        public IHttpActionResult PostPetType(PetType pettype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetType.Add(pettype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pettype.Id }, pettype);
        }

        // DELETE api/PetType/5
        [ResponseType(typeof(PetType))]
        public IHttpActionResult DeletePetType(int id)
        {
            PetType pettype = db.PetType.Find(id);
            if (pettype == null)
            {
                return NotFound();
            }

            db.PetType.Remove(pettype);
            db.SaveChanges();

            return Ok(pettype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetTypeExists(int id)
        {
            return db.PetType.Count(e => e.Id == id) > 0;
        }
    }
}