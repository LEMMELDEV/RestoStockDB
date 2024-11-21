using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.Proovedor
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<Proovedores> Proovedor { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Proovedor != null)
            {
                Proovedor = await _context.Proovedor.ToListAsync();
            }
        }
    }
}
