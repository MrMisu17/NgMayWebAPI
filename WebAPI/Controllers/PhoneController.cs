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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PhoneController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Phone
        public IQueryable<Phone> GetPhone()
        {
            return db.Phone;
        }

        // GET: api/Phone/5
        [ResponseType(typeof(Phone))]
        public IHttpActionResult GetPhone(int id)
        {
            Phone phone = db.Phone.Find(id);
            if (phone == null)
            {
                return NotFound();
            }

            return Ok(phone);
        }

        // PUT: api/Phone/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhone(int id, Phone phone)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            if (id != phone.ID)
            {
                return BadRequest();
            }

            db.Entry(phone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(id))
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

        // POST: api/Phone
        [ResponseType(typeof(Phone))]
        public IHttpActionResult PostPhone(Phone phone)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            db.Phone.Add(phone);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phone.ID }, phone);
        }

        // DELETE: api/Phone/5
        [ResponseType(typeof(Phone))]
        public IHttpActionResult DeletePhone(int id)
        {
            Phone phone = db.Phone.Find(id);
            if (phone == null)
            {
                return NotFound();
            }

            db.Phone.Remove(phone);
            db.SaveChanges();

            return Ok(phone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneExists(int id)
        {
            return db.Phone.Count(e => e.ID == id) > 0;
        }
    }
}