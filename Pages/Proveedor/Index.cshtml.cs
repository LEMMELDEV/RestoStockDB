using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStockDB.DATA;
using RestoStockDB.Models;

namespace RestoStockDB.Pages.Proveedor
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<Proveedores> Proveedor { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Proveedor != null)
            {
                Proveedor = await _context.Proveedor.ToListAsync();
            }
        }
    }
}