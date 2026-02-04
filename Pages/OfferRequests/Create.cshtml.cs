using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Dtos;
using WebApplication3.RequestManagement;
using WebApplication3.Workflows;

namespace WebApplication3.Pages.OfferRequests
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication3.Data.DataContext _context;

        public CreateModel(WebApplication3.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public OfferRequestInput Input { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }  


            var request = new OfferRequest
            {
                Description = Input.Description,
                Status = StatusEnum.Drafted,
                State = StateEnum.Started
            };

            _context.OfferRequests.Add(request);
            await _context.SaveChangesAsync();

            OfferRequestHistory offerRequestHistory = new OfferRequestHistory
            {
                OfferRequestId = request.Id,
                PreviousStatus = StatusEnum.None,
                ActionTaken = ActionEnum.CreateRequest,
                NewStatus = StatusEnum.Drafted,
                CreatedBy = Keys.ActorConsts.Salesperson,
            };
            _context.OfferRequestHistories.Add(offerRequestHistory);


            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
