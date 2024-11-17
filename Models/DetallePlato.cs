namespace RestoStockDB.Models
{
    public class DetallePlato
    {
        public int IdDetalle { get; set; } // Llave primaria

        // Llaves foráneas
        public int IdPlato { get; set; }
        public Plato Plato { get; set; }

        public int IdIngrediente { get; set; }
        public Ingrediente Ingrediente { get; set; }

        public decimal Cantidad { get; set; }

    }
}
