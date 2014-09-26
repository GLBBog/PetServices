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
    public class CityController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/City
        public IQueryable<City> GetCity()
        {
            return db.City;
        }

        // GET api/City/5
        [ResponseType(typeof(City))]
        public IHttpActionResult GetCity(int id)
        {
            City city = db.City.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT api/City/5
        public IHttpActionResult PutCity(int id, City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.Id)
            {
                return BadRequest();
            }

            db.Entry(city).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST api/City
        [ResponseType(typeof(City))]
        public IHttpActionResult PostCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.City.Add(city);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = city.Id }, city);
        }

        // DELETE api/City/5
        [ResponseType(typeof(City))]
        public IHttpActionResult DeleteCity(int id)
        {
            City city = db.City.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            db.City.Remove(city);
            db.SaveChanges();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityExists(int id)
        {
            return db.City.Count(e => e.Id == id) > 0;
        }
    }
}