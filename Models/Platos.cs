namespace RestoStockDB.Models
{
    public class Platos
    {
        public int Id { get; set; } // Llave primaria
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public string? Descripcion { get; set; }

        // Relación muchos-a-muchos con Ingrediente a través de DetallePlato
<<<<<<< HEAD
        public ICollection<DetallesPlato> DetallesPlatos { get; set; }
=======
        public ICollection<DetallePlato>? DetallesPlato { get; set; } = default!;
>>>>>>> df67b352963099bd0de508970ca74d73f781f69a

    }
}
