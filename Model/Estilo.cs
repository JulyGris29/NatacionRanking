using System;
using System.Collections.Generic;

namespace NatacionProyecto.Model
{
    public partial class Estilo
    {
        public Estilo()
        {
            MetricasNadadores = new HashSet<MetricasNadadore>();
        }

        public int Id { get; set; }
        public string NombreEstilo { get; set; } = null!;

        public virtual ICollection<MetricasNadadore> MetricasNadadores { get; set; }
    }
}
