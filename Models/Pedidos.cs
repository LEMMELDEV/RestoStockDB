namespace RestoStockDB.Models
{
    public class Pedidos
    {
        public int Id { get; set; } // Llave primaria

        // Llave foránea
        public int IdProveedor { get; set; }
        public Proveedores Proveedores { get; set; }

        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }
    }
}
