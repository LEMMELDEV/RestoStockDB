using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.Proveedor
{
    public class EditModel : PageModel
    {

        private readonly RestoStockContext _context;
        public EditModel(RestoStockContext context)
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //return Page(); // Si el modelo no es válido, vuelve a la misma página
            }
            _context.Attach(Proveedores).State = EntityState.Modified; // Marca la entidad como modificada
            try
            {
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            }
            catch (DbUpdateConcurrencyException) // Si ocurre un error de concurrencia
            {
                if (!ProveedoresExists(Proveedores.Id)) // Si el proveedor ya no existe
                {
                    return NotFound(); // Devuelve un error 404
                }
                else
                {
                    throw; // Re lanza la excepción para que sea manejada por niveles superiores
                }
            }
            return RedirectToPage("./Index"); // Redirige a la página de índice
        }
        private bool ProveedoresExists(int id)
        {
            return (_context.Proveedor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
