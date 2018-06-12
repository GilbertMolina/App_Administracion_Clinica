using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    public class CitasPacientesController : ApiController
    {
        private AdministracionClinicaBDContext db = new AdministracionClinicaBDContext();

        // GET: api/CitasPacientes
        public IEnumerable<CitasPacientesVM> GetCitasPacientes()
        {
            List<CitasPacientesVM> listaCitasPacientes = new List<CitasPacientesVM>();

            db.CitasPacientes.ToList().ForEach(cp => listaCitasPacientes.Add(new CitasPacientesVM()
            {
                Id = cp.Id,
                FechaCita = cp.FechaCita,
                IdPaciente = cp.IdPaciente,
                IdTipoCita = cp.IdTipoCita,
                IdEstadoCita = cp.IdEstadoCita,
                Pacientes = new PacientesVM() { Id = cp.Pacientes.Id, Nombre = cp.Pacientes.Nombre, Apellido1 = cp.Pacientes.Apellido1, Apellido2 = cp.Pacientes.Apellido2 },
                TiposCitas = new TiposCitasVM() { Id = cp.TiposCitas.Id, Nombre = cp.TiposCitas.Nombre },
                EstadosCitas = new EstadosCitasVM() { Id = cp.EstadosCitas.Id, Nombre = cp.EstadosCitas.Nombre }
            }));

            return listaCitasPacientes;
        }

        // GET: api/CitasPacientes/5
        [ResponseType(typeof(CitasPacientesVM))]
        public IHttpActionResult GetCitasPacientes(int id)
        {
            CitasPacientes cp = db.CitasPacientes.SingleOrDefault(x => x.Id == id);

            if (cp == null)
            {
                return NotFound();
            }

            List<EstadosCitasVM> listaEstadosCitas = new List<EstadosCitasVM>();

            db.EstadosCitas.OrderBy(x => x.Nombre).ToList().ForEach(ec => listaEstadosCitas.Add(new EstadosCitasVM()
            {
                Id = ec.Id,
                Nombre = ec.Nombre
            }));

            List<TiposCitasVM> listaTiposCitas = new List<TiposCitasVM>();

            db.TiposCitas.OrderBy(x => x.Nombre).ToList().ForEach(tc => listaTiposCitas.Add(new TiposCitasVM()
            {
                Id = tc.Id,
                Nombre = tc.Nombre
            }));

            CitasPacientesVM citaPaciente = new CitasPacientesVM()
            {
                Id = cp.Id,
                FechaCita = cp.FechaCita,
                IdPaciente = cp.IdPaciente,
                IdTipoCita = cp.IdTipoCita,
                IdEstadoCita = cp.IdEstadoCita,
                Pacientes = new PacientesVM() { Id = cp.Pacientes.Id, Nombre = cp.Pacientes.Nombre, Apellido1 = cp.Pacientes.Apellido1, Apellido2 = cp.Pacientes.Apellido2 },
                ListaEstadosCitas = listaEstadosCitas,
                ListaTiposCitas  = listaTiposCitas
            };

            return Ok(citaPaciente);
        }

        // PUT: api/CitasPacientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCitasPacientes(int id, CitasPacientes citasPacientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != citasPacientes.Id)
            {
                return BadRequest();
            }

            db.Entry(citasPacientes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitasPacientesExists(id))
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

        // POST: api/CitasPacientes
        [ResponseType(typeof(CitasPacientes))]
        public IHttpActionResult PostCitasPacientes(CitasPacientes citasPacientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CitasPacientes nuevaCitaPacienteConMismaFechaCita = db.CitasPacientes.SingleOrDefault(cp => cp.IdPaciente == citasPacientes.IdPaciente 
                && cp.FechaCita.Year == citasPacientes.FechaCita.Year
                && cp.FechaCita.Month == citasPacientes.FechaCita.Month
                && cp.FechaCita.Day == citasPacientes.FechaCita.Day);

            if (nuevaCitaPacienteConMismaFechaCita != null)
            {
                var mensaje = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Violacion unique constraint")
                };

                throw new HttpResponseException(mensaje);
            }

            db.CitasPacientes.Add(citasPacientes);

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = citasPacientes.Id }, citasPacientes);
        }

        // DELETE: api/CitasPacientes/5
        [ResponseType(typeof(CitasPacientes))]
        public IHttpActionResult DeleteCitasPacientes(int id)
        {
            CitasPacientes citasPacientes = db.CitasPacientes.SingleOrDefault(x => x.Id == id);

            if (citasPacientes == null)
            {
                return NotFound();
            }

            db.CitasPacientes.Remove(citasPacientes);

            db.SaveChanges();

            return Ok(citasPacientes);
        }

        private bool CitasPacientesExists(int id)
        {
            return db.CitasPacientes.Count(e => e.Id == id) > 0;
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