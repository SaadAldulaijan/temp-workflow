using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Dtos;
using WebApplication3.RequestManagement;

namespace WebApplication3.Pages.OfferRequests;

public class EditModel : PageModel
{
    private readonly DataContext _context;

    public EditModel(DataContext context)
    {
        _context = context;
    }

    [BindProperty]
    public OfferRequestUpdateInput Input { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var offerRequest = await _context.OfferRequests.FirstOrDefaultAsync(m => m.Id == id);

        if (offerRequest == null) return NotFound();

        Input = new OfferRequestUpdateInput
        {
            Description = offerRequest.Description,
            Id = offerRequest.Id
        };

        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var offerRequest = await _context.OfferRequests.FirstOrDefaultAsync(m => m.Id == Input.Id);

        if (offerRequest == null) return NotFound();

        offerRequest.Description = Input.Description;
        _context.Attach(offerRequest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OfferRequestExists(Input.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool OfferRequestExists(int id)
    {
        return _context.OfferRequests.Any(e => e.Id == id);
    }
}
