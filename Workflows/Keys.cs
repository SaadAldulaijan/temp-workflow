namespace WebApplication3.Workflows;


public static class Keys
{
    public static class ActorConsts
    {
        public const string Salesperson = "salesperson";
        public const string EngineeringCoordinator = "engineering-coordinator";
        public const string Engineer = "engineer";
        public const string EngineeringReviewer = "engineering-reivewer";
    }


    public static class StateConsts
    {
        public const string Drafted = "Drafted";
        public const string SubmittedBySalesAndPendingEngineeringAssignment = "SubmittedBySalesAndPendingEngineeringAssignment";
        public const string AssignedToEngineerByCoordinator = "AssignedToEngineerByCoordinator";
        public const string AcceptedAssignmentByEngineer = "AcceptedAssignmentByEngineer";
        public const string SubmittedByEngineerForReview = "SubmittedByEngineerForReview";
        public const string ApprovedByEngineeringReviewer = "ApprovedByEngineeringReviewer";
        public const string QuotationInProgress = "QuotationInProgress";
        public const string Awarded = "Awarded";
        public const string Lost = "Lost";
        public const string ReturnedByCoordinatorForSalespersonReview = "ReturnedByCoordinatorForSalespersonReview";
        public const string ReturnedByEngineerToCoordinatorForReassign = "ReturnedByEngineerToCoordinatorForReassign";
        public const string ReturnedBySalesToEngineeringReviewer = "ReturnedBySalesToEngineeringReviewer";
    }

    public static class ActionConsts
    {
        public const string CreateRequest = "create request";
        public const string SubmitToEngineering = "submit to enginnering";
        public const string AssignToEngineer = "assign to engineer";
        public const string ReturnToSales = "return to sales";
        public const string Accept = "accept";
        public const string ReturnToEngCoordinator = "return to eng. coordinator";
        public const string SubmitForReview = "submit for review";
        public const string Approve = "approve";
        public const string Return = "return";
        public const string Awarded = "awarded";
        public const string Lost = "lost";
    }
}
