namespace RestoStockDB.Models
{
    public class Proveedores
    {
        public int IdProveedor { get; set; } // Llave primaria
        public string NombreEmpresa { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        // Relación uno-a-muchos con Pedido
        public ICollection<Pedido> Pedidos { get; set; }
    }
