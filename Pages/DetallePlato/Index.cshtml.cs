using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.DetallePlato
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<DetallePlato> DetallesPlatos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DetallePlatos != null)
            {
                DetallePlatos = await _context.DetallePlatos
                    .Include(dp => dp.Platos) // Incluye la relaci�n con Platos
                    .Include(dp => dp.Ingredientes) // Incluye la relaci�n con Ingredientes
                    .ToListAsync();
            }
        }
    }
}


