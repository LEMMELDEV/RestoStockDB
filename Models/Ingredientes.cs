﻿using System.Net.Mime;
using RestoStockDB.DATA;

namespace RestoStockDB.Models
{
    public class Ingredientes
    {
            public int Id { get; set; } // PK
            public string Nombre { get; set; }
            public decimal CantidadDisponible { get; set; }
            public string UnidadMedida { get; set; }
            public decimal PrecioUnitario { get; set; }
        public ICollection<DetallePlato> DetallesPlatos { get; set; }

    }

}
