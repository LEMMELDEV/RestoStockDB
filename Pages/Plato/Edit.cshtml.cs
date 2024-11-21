using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.Plato
{
    public class EditModel : PageModel
    {

        private readonly RestoStockContext _context;
        public EditModel(RestoStockContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Proovedores Platos { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Proovedor == null)
            {
                return NotFound();
            }
            var platos = await _context.Proovedor.FirstOrDefaultAsync(m => m.IdPlato == id);
            if (platos == null)
            {
                return NotFound();
            }
            else
            {
                Platos = platos;
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //return Page(); // Si el modelo no es válido, vuelve a la misma página
            }
            _context.Attach(Platos).State = EntityState.Modified; // Marca la entidad como modificada
            try
            {
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            }
            catch (DbUpdateConcurrencyException) // Si ocurre un error de concurrencia
            {
                if (!PlatosExists(Platos.IdPlato)) // Si la categoría ya no existe
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
        private bool PlatosExists(int id)
        {
            return (_context.Proovedor?.Any(e => e.IdPlato == id)).GetValueOrDefault();
        }
    }
}