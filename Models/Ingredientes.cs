using System.Net.Mime;

namespace RestoStockDB.Models
{
    public class Ingredientes
    {
            public int IdIngrediente { get; set; } // PK
            public string Nombre { get; set; }
            public decimal CantidadDisponible { get; set; }
            public string UnidadMedida { get; set; }
            public decimal PrecioUnitario { get; set; }
        public ICollection<DetallePlato> DetallesPlatos { get; set; }

    }

}
