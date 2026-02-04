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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication3.Data.DataContext _context;

        public DeleteModel(WebApplication3.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OfferRequest OfferRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerrequest = await _context.OfferRequests.FirstOrDefaultAsync(m => m.Id == id);

            if (offerrequest is not null)
            {
                OfferRequest = offerrequest;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerrequest = await _context.OfferRequests.FindAsync(id);
            if (offerrequest != null)
            {
                OfferRequest = offerrequest;
                _context.OfferRequests.Remove(OfferRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
