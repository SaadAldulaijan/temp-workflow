namespace WebApplication3.Workflows;

public class WorkflowStatus
{
    public StatusEnum Id { get; set; }
    public string StatusName { get; set; } = default!;
    public StateEnum State { get; set; }
    public string ActorRole { get; set; } = default!;
    public virtual ICollection<WorkflowTransition> Transitions { get; set; } = [];
}






//public class WorkflowStatus
//{
//    public int Id { get; set; }
//    public StatusEnum? Status { get; set; }
//    public StateEnum State { get; set; }
//    public string? Name { get; set; }
//    public string ActorRole { get; set; } = default!;
//    public List<WorkflowTransition>? Transitions { get; set; } = [];
//}



//public class WorkflowTransition
//{
//    public int Id { get; set; }
//    public StatusEnum Status { get; set; }
//    public string Name { get; set; } = default!;
//    public WorkflowAction Action { get; set; } = default!;

//    public Precondition? Precondition { get; set; }

//}


//public record WorkflowAction(int Id, string Name, ActionEnum Action);

//public record Precondition(bool CommentRequired, bool DataRequired, bool AssignmentRequired);

