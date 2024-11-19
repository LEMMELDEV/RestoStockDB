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
            var Platos = await _context.Plato.FirstOrDefaultAsync(m => m.Id == id);
            if (Platos == null)
            {
                return NotFound();
            }
            else
            {
                Platos = Platos;
                return Page();
            }
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Verifica si el id es nulo o si el contexto de m�todos de pago es nulo.
            if (id == null || _context.Plato == null)
            {
                // Si alguna de las condiciones anteriores es verdadera, se devuelve un error 404 (Not Found).
                return NotFound();
            }
            // Busca el Plato con el id proporcionado de forma as�ncrona.
            var Platos = await _context.Plato.FindAsync(id);
            // Si el m�todo de pago no se encuentra, se devuelve un error 404.
            if (Platos == null)
            {
                return NotFound();
            }
            // Si se encuentra el Plato, se procede a eliminarlo.
            Platos = Platos; // Asigna el Plato encontrado a la propiedad PayMode.
            _context.Plato.Remove(Platos); // Elimina el Plato del contexto.
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos de forma as�ncrona.
            // Redirige a la p�gina de �ndice despu�s de eliminar el Plato.
            return RedirectToPage("./Index");
        }
    }
}