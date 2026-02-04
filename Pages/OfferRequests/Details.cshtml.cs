using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;
using WebApplication3.Data;
using WebApplication3.RequestManagement;
using WebApplication3.Workflows;

namespace WebApplication3.Pages.OfferRequests
{
    public class DetailsModel : PageModel
    {
        private readonly DataContext _context;

        public DetailsModel(DataContext context)
        {
            _context = context;
        }

        public OfferRequest OfferRequest { get; set; } = default!;

        public WorkflowStatus CurrentState { get; set; }

        [BindProperty]
        public SelectedActionInput Input { get; set; }

        public WorkflowTransition[] HappyScenarios { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var offerRequest = await _context.OfferRequests
                .Where(m => m.Id == id)
                .Include(x => x.OfferRequestHistories)
                .FirstOrDefaultAsync();

            if (offerRequest is null) return NotFound();
            
            OfferRequest = offerRequest;

            // get next workflow transisions
            //var currentState = WorkflowData.WorkflowStatuses.FirstOrDefault(x => x.Status == offerRequest.Status);
            var currentState = await _context.WorkflowStatuses
                .Include(x => x.Transitions)
                .FirstOrDefaultAsync(x => x.Id == offerRequest.Status);

            if (currentState is null) return NotFound();

            CurrentState = currentState;

            HappyScenarios = await LoadHappyScenariosAsync();

            return Page();
        }


        private async Task<WorkflowTransition[]> LoadHappyScenariosAsync()
        {
            return await _context.WorkflowTransitions
                .Include(x => x.FromStatus)
                .Include(x => x.ToStatus).ToArrayAsync();
        }


        public async Task<IActionResult> OnPostAsync()
        {

            // change offer request state to the submitted state
            var offerRequest = await _context.OfferRequests.FirstOrDefaultAsync(m => m.Id == Input.RequestId);

            if (offerRequest is null) return NotFound();

            OfferRequestHistory offerRequestHistory = new OfferRequestHistory
            {
                OfferRequestId = offerRequest.Id,
                PreviousStatus = offerRequest.Status,
                ActionTaken = Input.ActionTaken,
                NewStatus = Input.Status,
                CreatedBy = Input.CreatedBy
            };

            _context.OfferRequestHistories.Add(offerRequestHistory);

            offerRequest.Status = Input.Status;
            
            _context.OfferRequests.Update(offerRequest);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}


public class SelectedActionInput
{
    public int Id { get; set; }
    public StatusEnum Status { get; set; }
    public ActionEnum ActionTaken { get; set; }
    public int RequestId { get; set; }
    public string CreatedBy { get; set; } = default!;

}