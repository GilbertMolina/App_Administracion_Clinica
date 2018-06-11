using System;

namespace WebAPI.ViewModels
{
    public class CitasPacientesVM
    {
        public int Id { get; set; }

        public int IdPaciente { get; set; }

        public int IdTipoCita { get; set; }

        public int IdEstadoCita { get; set; }

        public PacientesVM Pacientes { get; set; }

        public EstadosCitasVM EstadosCitas { get; set; }

        public TiposCitasVM TiposCitas { get; set; }

        public DateTime FechaCita { get; set; }
    }
}