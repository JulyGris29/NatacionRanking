using System;
using System.Collections.Generic;

namespace NatacionProyecto.Model
{
    public partial class Persona
    {
        public Persona()
        {
            InverseTipoIdentificacion = new HashSet<Persona>();
            Nadadores = new HashSet<Nadadore>();
        }

        public int Id { get; set; }
        public string Identificacion { get; set; } = null!;
        public int TipoIdentificacionId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual Persona TipoIdentificacion { get; set; } = null!;
        public virtual ICollection<Persona> InverseTipoIdentificacion { get; set; }
        public virtual ICollection<Nadadore> Nadadores { get; set; }
    }
}
