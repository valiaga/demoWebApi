﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DemoWebApii.Models;

namespace DemoWebApii.Controllers
{
    public class PersonaController : ApiController
    {
        private PersonaDBContext db = new PersonaDBContext();

        // GET api/Persona
        public IQueryable<Persona> GetPersona()
        {
            return db.Persona;
        }

        // GET api/Persona/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult GetPersona(int id)
        {
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT api/Persona/5
        public IHttpActionResult PutPersona(int id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id)
            {
                return BadRequest();
            }

            db.Entry(persona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST api/Persona
        [ResponseType(typeof(Persona))]
        public IHttpActionResult PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persona.Add(persona);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, persona);
        }

        // DELETE api/Persona/5
        [ResponseType(typeof(Persona))]
        public IHttpActionResult DeletePersona(int id)
        {
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.Persona.Remove(persona);
            db.SaveChanges();

            return Ok(persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(int id)
        {
            return db.Persona.Count(e => e.Id == id) > 0;
        }
    }
}