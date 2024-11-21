namespace RestoStockDB.Models

{
    public class DetallePlato
    {
        public int Id { get; set; } // Llave primaria

        // Llaves foráneas
        public int Id { get; set; }
        public Platos Platos { get; set; }

        public int IdIngrediente { get; set; }
        public Ingredientes Ingredientes { get; set; }

        public decimal Cantidad { get; set; }

    }

}