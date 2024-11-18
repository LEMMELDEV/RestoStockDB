using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.DetallePlatos
{
    public class CreateModel : PageModel
    {
        private readonly RestoStockContext _context;

        public CreateModel(RestoStockContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Llenar listas desplegables para Platos e Ingredientes
            ViewData["IdPlato"] = new SelectList(_context.Plato, "Id", "Nombre");
            ViewData["IdIngrediente"] = new SelectList(_context.Ingrediente, "Id", "Nombre");
            return Page();
        }

        [BindProperty]
        public DetallePlato DetallePlato { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Recargar listas desplegables en caso de error
                ViewData["IdPlato"] = new SelectList(_context.Plato, "Id", "Nombre");
                ViewData["IdIngrediente"] = new SelectList(_context.Ingrediente, "Id", "Nombre");
                return Page();
            }

            _context.DetallesPlato.Add(DetallePlato);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
