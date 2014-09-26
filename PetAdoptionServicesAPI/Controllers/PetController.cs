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
    public class PetController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/Pet
        public IQueryable<Pet> GetPet()
        {
            return db.Pet;
        }

        // GET api/Pet/5
        [ResponseType(typeof(Pet))]
        public IHttpActionResult GetPet(long id)
        {
            Pet pet = db.Pet.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        // PUT api/Pet/5
        public IHttpActionResult PutPet(long id, Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pet.Id)
            {
                return BadRequest();
            }

            db.Entry(pet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
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

        // POST api/Pet
        [ResponseType(typeof(Pet))]
        public IHttpActionResult PostPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pet.Add(pet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pet.Id }, pet);
        }

        // DELETE api/Pet/5
        [ResponseType(typeof(Pet))]
        public IHttpActionResult DeletePet(long id)
        {
            Pet pet = db.Pet.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            db.Pet.Remove(pet);
            db.SaveChanges();

            return Ok(pet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PetExists(long id)
        {
            return db.Pet.Count(e => e.Id == id) > 0;
        }
    }
}