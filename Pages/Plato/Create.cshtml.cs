using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.Plato
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
            return Page();
        }

        [BindProperty]
        public
     Proovedores Platos
        { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Proovedor == null || Platos == null)
            {
                return Page();

            }

            _context.Proovedor.Add(Platos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}