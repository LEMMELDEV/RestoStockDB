using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.Proveedor
{
    public class DeleteModel : PageModel
    {
        private readonly RestoStockContext _context;
        public DeleteModel(RestoStockContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Proveedores Proveedores { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Proveedor == null)
            {
                return NotFound();
            }
            var proveedores = await _context.Proveedor.FirstOrDefaultAsync(m => m.Id == id);
            if (proveedores == null)
            {
                return NotFound();
            }
            else
            {
                Proveedores = proveedores;
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Verifica si el id es nulo o si el contexto de proveedores es nulo.
            if (id == null || _context.Proveedor == null)
            {
                // Si alguna de las condiciones anteriores es verdadera, se devuelve un error 404 (Not Found).
                return NotFound();
            }
            // Busca el Proveedor con el id proporcionado de forma asíncrona.
            var proveedores = await _context.Proveedor.FindAsync(id);
            // Si el Proveedor no se encuentra, se devuelve un error 404.
            if (proveedores == null)
            {
                return NotFound();
            }
            // Si se encuentra el Proveedor, se procede a eliminarlo.
            Proveedores = proveedores; // Asigna el Proveedor encontrado a la propiedad Proveedores.
            _context.Proveedor.Remove(Proveedores); // Elimina el Proveedor del contexto.
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos de forma asíncrona.
            // Redirige a la página de índice después de eliminar el Proveedor.
            return RedirectToPage("./Index");
        }
    }
}
