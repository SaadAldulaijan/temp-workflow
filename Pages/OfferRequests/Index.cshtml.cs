using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.RequestManagement;

namespace WebApplication3.Pages.OfferRequests
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication3.Data.DataContext _context;

        public IndexModel(WebApplication3.Data.DataContext context)
        {
            _context = context;
        }

        public IList<OfferRequest> OfferRequest { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OfferRequest = await _context.OfferRequests
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
    }
}
