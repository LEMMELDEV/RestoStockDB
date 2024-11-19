using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;
namespace RestoStockDB.Pages.Plato
{
    public class DeleteModel : PageModel
    {
        private readonly RestoStockContext _context;
        public DeleteModel(RestoStockContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Platos Platos { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Plato == null)
            {
                return NotFound();
            }
            var platos = await _context.Plato.FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Verifica si el id es nulo o si el contexto de métodos de pago es nulo.
            if (id == null || _context.Plato == null)
            {
                // Si alguna de las condiciones anteriores es verdadera, se devuelve un error 404 (Not Found).
                return NotFound();
            }
            // Busca el Plato con el id proporcionado de forma asíncrona.
            var Platos = await _context.Plato.FindAsync(id);
            // Si el Plato no se encuentra, se devuelve un error 404.
            if (Platos == null)
            {
                return NotFound();
            }
            // Si se encuentra el Plato, se procede a eliminarlo.
            Platos = Platos; // Asigna el Plato encontrado a la propiedad Platos.
            _context.Plato.Remove(Platos); // Elimina el Plato del contexto.
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos de forma asíncrona.
            // Redirige a la página de índice después de eliminar el Plato.
            return RedirectToPage("./Index");
        }
    }
}