using System;
using System.Collections.Generic;

namespace NatacionProyecto
{
    public partial class MetricasNadadore
    {
        public int Id { get; set; }
        public int NadadorId { get; set; }
        public decimal Distancia { get; set; }
        public int MedidaDistanciaId { get; set; }
        public DateTime Tiempo { get; set; }
        public int EstiloId { get; set; }
        public DateTime? FechaMetrica { get; set; }

        public virtual Estilo Estilo { get; set; } = null!;
        public virtual Medida MedidaDistancia { get; set; } = null!;
        public virtual Nadadore Nadador { get; set; } = null!;
    }
}
