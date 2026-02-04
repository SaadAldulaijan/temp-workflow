namespace WebApplication3.Workflows;

public class WorkflowTransition
{
    public int Id { get; set; }
    public StatusEnum FromStatusId { get; set; }
    public StatusEnum ToStatusId { get; set; }
    public ActionEnum Action { get; set; }
    public virtual WorkflowStatus FromStatus { get; set; } = default!;
    public virtual WorkflowStatus ToStatus { get; set; } = default!;
    public virtual TransitionPrecondition? Precondition { get; set; }
}

public class TransitionPrecondition
{
    public bool CommentRequired { get; set; }
    public bool DataRequired { get; set; }
    public bool AssignmentRequired { get; set; }
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

