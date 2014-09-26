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
    public class CountryController : ApiController
    {
        private PetAdoptionDBEntities db = new PetAdoptionDBEntities();

        // GET api/Country
        public IQueryable<Country> GetCountry()
        {
            return db.Country;
        }

        // GET api/Country/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult GetCountry(int id)
        {
            Country country = db.Country.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // PUT api/Country/5
        public IHttpActionResult PutCountry(int id, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.Id)
            {
                return BadRequest();
            }

            db.Entry(country).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST api/Country
        [ResponseType(typeof(Country))]
        public IHttpActionResult PostCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Country.Add(country);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = country.Id }, country);
        }

        // DELETE api/Country/5
        [ResponseType(typeof(Country))]
        public IHttpActionResult DeleteCountry(int id)
        {
            Country country = db.Country.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            db.Country.Remove(country);
            db.SaveChanges();

            return Ok(country);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryExists(int id)
        {
            return db.Country.Count(e => e.Id == id) > 0;
        }
    }
}