namespace RestoStockDB.Models
{
    public class DetallePlato
    {
        public int IdDetalle { get; set; } // Llave primaria

        // Llaves foráneas
        public int IdPlato { get; set; }
        public Proovedores Platos { get; set; }

        public int IdIngrediente { get; set; }
        public Ingredientes Ingredientes { get; set; }

        public decimal Cantidad { get; set; }

    }
}
