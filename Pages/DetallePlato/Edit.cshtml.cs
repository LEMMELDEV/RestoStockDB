using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.DetallePlato
{
    public class EditModel : PageModel
    {
        private readonly RestoStockContext _context;

        public EditModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DetallePlato DetallePlato { get; set; } = default!;

        // M�todo GET para obtener un DetallePlato por su ID
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DetallePlato == null)
            {
                return NotFound(); // Devuelve un error 404 si no se proporciona un ID o si no hay datos
            }

            var detallePlato = await _context.DetallePlato
                .Include(dp => dp.Platos) // Incluye los datos relacionados de Platos
                .Include(dp => dp.Ingredientes) // Incluye los datos relacionados de Ingredientes
                .FirstOrDefaultAsync(m => m.IdDetalle == id);

            if (detallePlato == null)
            {
                return NotFound(); // Devuelve un error 404 si no se encuentra el registro
            }
            else
            {
                DetallePlato = detallePlato;
            }

            return Page(); // Devuelve la p�gina con los datos cargados
        }

        // M�todo POST para actualizar los datos de DetallePlato
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Si el modelo no es v�lido, vuelve a la misma p�gina
            }

            _context.Attach(DetallePlato).State = EntityState.Modified; // Marca la entidad como modificada

            try
            {
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            }
            catch (DbUpdateConcurrencyException) // Si ocurre un error de concurrencia
            {
                if (!DetallePlatoExists(DetallePlato.IdDetalle)) // Verifica si el registro todav�a existe
                {
                    return NotFound(); // Devuelve un error 404 si el registro ya no existe
                }
                else
                {
                    throw; // Re-lanza la excepci�n si es otro error
                }
            }

            return RedirectToPage("./Index"); // Redirige a la p�gina de �ndice despu�s de actualizar
        }

        // M�todo auxiliar para verificar si un DetallePlato existe en la base de datos
        private bool DetallePlatoExists(int id)
        {
            return (_context.DetallePlatos?.Any(e => e.IdDetalle == id)).GetValueOrDefault();
        }
    }
}

