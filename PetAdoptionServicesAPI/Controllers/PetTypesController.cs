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
    public class PetTypesController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/PetTypes
        public IQueryable<PetType> GetPetTypes()
        {
            return db.PetTypes;
        }

        // GET api/PetTypes/5
        [ResponseType(typeof(PetType))]
        public IHttpActionResult GetPetType(int id)
        {
            PetType pettype = db.PetTypes.Find(id);
            if (pettype == null)
            {
                return NotFound();
            }

            return Ok(pettype);
        }

        // PUT api/PetTypes/5
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

        // POST api/PetTypes
        [ResponseType(typeof(PetType))]
        public IHttpActionResult PostPetType(PetType pettype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PetTypes.Add(pettype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pettype.Id }, pettype);
        }

        // DELETE api/PetTypes/5
        [ResponseType(typeof(PetType))]
        public IHttpActionResult DeletePetType(int id)
        {
            PetType pettype = db.PetTypes.Find(id);
            if (pettype == null)
            {
                return NotFound();
            }

            db.PetTypes.Remove(pettype);
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
            return db.PetTypes.Count(e => e.Id == id) > 0;
        }
    }
}