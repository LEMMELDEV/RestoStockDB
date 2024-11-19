namespace RestoStockDB.Models
{
    public class Platos
    {
        public int IdPlato { get; set; } // Llave primaria
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public string? Descripcion { get; set; }

        // Relación muchos-a-muchos con Ingrediente a través de DetallePlato
        public ICollection<DetallesPlato> DetallesPlatos { get; set; }

    }
}
