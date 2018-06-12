using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    public class EstadosCitasController : ApiController
    {
        private AdministracionClinicaBDContext db = new AdministracionClinicaBDContext();

        // GET: api/EstadosCitas
        public List<EstadosCitasVM> GetEstadosCitas()
        {
            List<EstadosCitasVM> listaEstadosCitas = new List<EstadosCitasVM>();

            db.EstadosCitas.OrderBy(x => x.Nombre).ToList().ForEach(ec => listaEstadosCitas.Add(new EstadosCitasVM()
            {
                Id = ec.Id,
                Nombre = ec.Nombre
            }));

            return listaEstadosCitas;
        }

        // GET: api/EstadosCitas/5
        [ResponseType(typeof(EstadosCitasVM))]
        public IHttpActionResult GetEstadosCitas(int id)
        {
            EstadosCitas ec = db.EstadosCitas.SingleOrDefault(x => x.Id == id);

            if (ec == null)
            {
                return NotFound();
            }

            EstadosCitasVM estadoCita = new EstadosCitasVM()
            {
                Id = ec.Id,
                Nombre = ec.Nombre
            };

            return Ok(estadoCita);
        }

        // PUT: api/EstadosCitas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstadosCitas(int id, EstadosCitas estadosCitas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadosCitas.Id)
            {
                return BadRequest();
            }

            db.Entry(estadosCitas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosCitasExists(id))
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

        // POST: api/EstadosCitas
        [ResponseType(typeof(EstadosCitas))]
        public IHttpActionResult PostEstadosCitas(EstadosCitas estadosCitas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadosCitas.Add(estadosCitas);

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estadosCitas.Id }, estadosCitas);
        }

        // DELETE: api/EstadosCitas/5
        [ResponseType(typeof(EstadosCitas))]
        public IHttpActionResult DeleteEstadosCitas(int id)
        {
            EstadosCitas estadosCitas = db.EstadosCitas.SingleOrDefault(x => x.Id == id);

            if (estadosCitas == null)
            {
                return NotFound();
            }

            db.EstadosCitas.Remove(estadosCitas);

            db.SaveChanges();

            return Ok(estadosCitas);
        }

        private bool EstadosCitasExists(int id)
        {
            return db.EstadosCitas.Count(e => e.Id == id) > 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}