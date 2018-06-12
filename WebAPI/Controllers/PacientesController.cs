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
    public class PacientesController : ApiController
    {
        private AdministracionClinicaBDContext db = new AdministracionClinicaBDContext();

        // GET: api/Pacientes
        public List<PacientesVM> GetPacientes()
        {
            List<PacientesVM> listaPacientes = new List<PacientesVM>();

            db.Pacientes.OrderBy(x => x.Id).ToList().ForEach(p => listaPacientes.Add(new PacientesVM()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido1 = p.Apellido1,
                Apellido2 = p.Apellido2
            }));

            return listaPacientes;
        }

        // GET: api/Pacientes/5
        [ResponseType(typeof(PacientesVM))]
        public IHttpActionResult GetPacientes(int id)
        {
            Pacientes p = db.Pacientes.SingleOrDefault(x => x.Id == id);

            if (p == null)
            {
                return NotFound();
            }

            PacientesVM paciente = new PacientesVM()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido1 = p.Apellido1,
                Apellido2 = p.Apellido2,
            };

            return Ok(paciente);
        }

        // PUT: api/Pacientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPacientes(int id, Pacientes pacientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pacientes.Id)
            {
                return BadRequest();
            }

            db.Entry(pacientes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacientesExists(id))
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

        // POST: api/Pacientes
        [ResponseType(typeof(Pacientes))]
        public IHttpActionResult PostPacientes(Pacientes pacientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacientes.Add(pacientes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PacientesExists(pacientes.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pacientes.Id }, pacientes);
        }

        // DELETE: api/Pacientes/5
        [ResponseType(typeof(Pacientes))]
        public IHttpActionResult DeletePacientes(int id)
        {
            Pacientes pacientes = db.Pacientes.SingleOrDefault(x => x.Id == id);

            if (pacientes == null)
            {
                return NotFound();
            }

            db.Pacientes.Remove(pacientes);

            db.SaveChanges();

            return Ok(pacientes);
        }

        private bool PacientesExists(int id)
        {
            return db.Pacientes.Count(e => e.Id == id) > 0;
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