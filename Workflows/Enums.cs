namespace WebApplication3.Workflows;


public enum StatusEnum
{
    None = 0,
    Drafted = 100,
    ReturnedByCoordinatorForSalespersonReview = 101,
    SubmittedBySalesAndPendingEngineeringAssignment = 200,
    ReturnedByEngineerToCoordinatorForReassign = 201,
    AssignedToEngineerByCoordinator = 300,
    AcceptedAssignmentByEngineer = 400,
    ApprovedByEngineeringReviewer = 600,
    SubmittedByEngineerForReview = 500,
    ReturnedBySalesToEngineeringReviewer = 501,
    ReturnedBySalesForEngineeringRework = 502,
    ReturnedByReviewerToEngineer = 401,
    QuotationInProgress = 700,
    Awarded = 800,
    Lost = 801
}

public enum ActionEnum
{
    CreateRequest,  
    Submit,
    Assign,
    Return,
    Accept,
    Approve,
    CreateQuotation,
    Awarded,
    Lost,
}

public enum StateEnum
{
    Started,
    InProgress,
    Completed,
    Returned
}
