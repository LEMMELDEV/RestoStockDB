using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.DetallesPlatos
{
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<DetallesPlato> DetallesPlatos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DetallesPlatos != null)
            {
                DetallesPlatos = await _context.DetallesPlatos.ToListAsync();
            }
        }
    }
}