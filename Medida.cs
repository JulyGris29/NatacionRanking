using System;
using System.Collections.Generic;

namespace NatacionProyecto
{
    public partial class Medida
    {
        public Medida()
        {
            MetricasNadadores = new HashSet<MetricasNadadore>();
        }

        public int Id { get; set; }
        public string Medida1 { get; set; } = null!;

        public virtual ICollection<MetricasNadadore> MetricasNadadores { get; set; }
    }
}
