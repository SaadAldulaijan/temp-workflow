using WebApplication3.Workflows;

namespace WebApplication3.RequestManagement;

public class OfferRequest
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public StatusEnum Status { get; set; } = default!;
    public StateEnum State { get; set; }
    public virtual ICollection<OfferRequestHistory> OfferRequestHistories { get; set; } = [];
}


public class OfferRequestHistory
{
    public int Id { get; set; }
    public int OfferRequestId { get; set; }
    public StatusEnum PreviousStatus { get; set; } = default!;
    public ActionEnum ActionTaken { get; set; }
    public StatusEnum NewStatus { get; set; } = default!;
    public string CreatedBy { get; set; } = default!;
    public DateTime CreationTime { get; set; }
}