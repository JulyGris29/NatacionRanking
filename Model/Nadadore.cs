using System;
using System.Collections.Generic;

namespace NatacionProyecto.Model
{
    public partial class Nadadore
    {
        public Nadadore()
        {
            MetricasNadadores = new HashSet<MetricasNadadore>();
        }

        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string Liga { get; set; } = null!;
        public int Categoria { get; set; }
        public string Genero { get; set; } = null!;

        public virtual Persona Persona { get; set; } = null!;
        public virtual ICollection<MetricasNadadore> MetricasNadadores { get; set; }
    }
}
