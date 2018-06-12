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
    public class TiposCitasController : ApiController
    {
        private AdministracionClinicaBDContext db = new AdministracionClinicaBDContext();

        // GET: api/TiposCitas
        public List<TiposCitasVM> GetTiposCitas()
        {
            List<TiposCitasVM> listaTiposCitas = new List<TiposCitasVM>();

            db.TiposCitas.OrderBy(x => x.Nombre).ToList().ForEach(tc => listaTiposCitas.Add(new TiposCitasVM()
            {
                Id = tc.Id,
                Nombre = tc.Nombre
            }));

            return listaTiposCitas;
        }

        // GET: api/TiposCitas/5
        [ResponseType(typeof(TiposCitasVM))]
        public IHttpActionResult GetTiposCitas(int id)
        {
            TiposCitas tc = db.TiposCitas.SingleOrDefault(x => x.Id == id);

            if (tc == null)
            {
                return NotFound();
            }

            TiposCitasVM estadoCita = new TiposCitasVM()
            {
                Id = tc.Id,
                Nombre = tc.Nombre
            };

            return Ok(estadoCita);
        }

        // PUT: api/TiposCitas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTiposCitas(int id, TiposCitas tiposCitas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tiposCitas.Id)
            {
                return BadRequest();
            }

            db.Entry(tiposCitas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposCitasExists(id))
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

        // POST: api/TiposCitas
        [ResponseType(typeof(TiposCitas))]
        public IHttpActionResult PostTiposCitas(TiposCitas tiposCitas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposCitas.Add(tiposCitas);

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tiposCitas.Id }, tiposCitas);
        }

        // DELETE: api/TiposCitas/5
        [ResponseType(typeof(TiposCitas))]
        public IHttpActionResult DeleteTiposCitas(int id)
        {
            TiposCitas tiposCitas = db.TiposCitas.SingleOrDefault(x => x.Id == id);

            if (tiposCitas == null)
            {
                return NotFound();
            }

            db.TiposCitas.Remove(tiposCitas);

            db.SaveChanges();

            return Ok(tiposCitas);
        }

        private bool TiposCitasExists(int id)
        {
            return db.TiposCitas.Count(e => e.Id == id) > 0;
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