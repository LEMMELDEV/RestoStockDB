using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.DetallesPlatos
{
    public class CreateModel : PageModel
    {
        private readonly RestoStockContext _context;

        public CreateModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
      // public DetallePlato DetallePlato { get; set; } = default!;

        public SelectList PlatosList { get; set; } = default!;
        public SelectList IngredientesList { get; set; } = default!;

        private async Task CargarSelectListsAsync()
        {
            PlatosList = new SelectList(await _context.Plato.ToListAsync(), "Id", "Nombre");
            IngredientesList = new SelectList(await _context.Ingrediente.ToListAsync(), "Id", "Nombre");
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await CargarSelectListsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CargarSelectListsAsync();
                return Page();
            }

           // _context.DetallesPlatos.Add(DetallePlato);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
