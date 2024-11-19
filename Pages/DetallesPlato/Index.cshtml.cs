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

        public IList<DetallePlato> DetallePlato { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DetallePlato != null)
            {
                DetallesPlato = await _context.DetallePlato.ToListAsync();
            }
        }
    }
}