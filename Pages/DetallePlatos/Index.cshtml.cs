using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.DetallePlatos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<DetallePlato> DetallesPlato { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DetallesPlato != null)
            {
                DetallesPlato = await _context.DetallesPlato
                                              .Include(dp => dp.Platos)
                                              .Include(dp => dp.Ingredientes)
                                              .ToListAsync();
            }
        }
    }
}