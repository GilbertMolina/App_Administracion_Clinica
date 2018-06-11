using System;
using System.Collections.Generic;

namespace App.Models
{
    public class CitaPacienteModel
    {
        public int Id { get; set; }

        public int IdPaciente { get; set; }

        public int IdTipoCita { get; set; }

        public int IdEstadoCita { get; set; }

        public DateTime FechaCita { get; set; }

        public IEnumerable<PacienteModel> Pacientes { get; set; }

        public IEnumerable<EstadoCitaModel> EstadosCitas { get; set; }

        public IEnumerable<TipoCitaModel> TiposCitas { get; set; }
    }
}