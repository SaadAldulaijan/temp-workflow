namespace WebApplication3.Workflows;



//public static class WorkflowData
//{
//    public static readonly IReadOnlyList<WorkflowStatus> WorkflowStatuses =
//    [
//        CreateRequestState,
//        ReturnedByCoordinatorForSalespersonReviewState,
//        DraftedState,
//        SubmittedBySalesAndPendingEngineeringAssignmentState,
//        ReturnedByEngineerToCoordinatorForReassignState,
//        AssignedToEngineerByCoordinatorState,
//        AcceptedAssignmentByEngineerState,
//        SubmittedByEngineerForReviewState,
//        ReturnedBySalesToEngineeringReviewerState,
//        ApprovedByEngineeringReviewerState,
//        QuotationInProgressState,
//        LostState,
//        AwardedState
//    ];


//    /// <summary>
//    /// Initial state of the workflow - offer request default status 
//    /// </summary>
//    private static WorkflowStatus CreateRequestState =>
//        new WorkflowStatus
//        {
//            Id = 1,
//            State = StateEnum.Started,
//            Status = null,
//            Name = null,
//            ActorRole = Keys.ActorConsts.Salesperson,
//            Transitions = [
//                new()
//                {
//                    Id = 100,
//                    Status = StatusEnum.Drafted,
//                    Name = Keys.StateConsts.Drafted,
//                    Action = new WorkflowAction(1, Keys.ActionConsts.CreateRequest, ActionEnum.CreateRequest)
//                }
//            ]
//        };

//    /// <summary>
//    /// After creating the request, the offer is in Draft state
//    /// </summary>
//    private static WorkflowStatus DraftedState =>
//         new WorkflowStatus
//         {
//             Id = 100,
//             State = StateEnum.InProgress,
//             Status = StatusEnum.Drafted,
//             Name = Keys.StateConsts.Drafted,
//             ActorRole = Keys.ActorConsts.Salesperson,
//             Transitions = [
//                new()
//                {
//                    Id = 200,
//                    Status = StatusEnum.SubmittedBySalesAndPendingEngineeringAssignment,
//                    Name = Keys.StateConsts.SubmittedBySalesAndPendingEngineeringAssignment,
//                    Action = new WorkflowAction(1, Keys.ActionConsts.SubmitToEngineering, ActionEnum.SubmitToEngineering)
//                }
//            ]
//         };

//    /// <summary>
//    /// When the coordinator returns the offer to salesperson for modifications
//    /// The salesperson can resubmit to engineering coordinator
//    /// </summary>
//    private static WorkflowStatus ReturnedByCoordinatorForSalespersonReviewState =>
//        new WorkflowStatus
//        {
//            Id = 101,
//            State = StateEnum.Returned,
//            Status = StatusEnum.ReturnedByCoordinatorForSalespersonReview,
//            Name = Keys.StateConsts.ReturnedByCoordinatorForSalespersonReview,
//            ActorRole = Keys.ActorConsts.Salesperson,
//            Transitions = [
//                new ()
//                {
//                    Id = 200,
//                    Status = StatusEnum.SubmittedBySalesAndPendingEngineeringAssignment,
//                    Name = Keys.StateConsts.SubmittedBySalesAndPendingEngineeringAssignment,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.SubmitToEngineering, ActionEnum.SubmitToEngineering),
//                    Precondition = new Precondition(true, false, false)
//                }
//            ]
//        };


//    /// <summary>
//    /// When the offer request is submitted by sales and waiting for engineering coordinator to 
//    /// - assign an engineer or 
//    /// - return to salesperson
//    /// </summary>
//    private static WorkflowStatus SubmittedBySalesAndPendingEngineeringAssignmentState =>
//        new WorkflowStatus
//        {
//            Id = 200,
//            State = StateEnum.InProgress,
//            Status = StatusEnum.SubmittedBySalesAndPendingEngineeringAssignment,
//            Name = Keys.StateConsts.SubmittedBySalesAndPendingEngineeringAssignment,
//            ActorRole = Keys.ActorConsts.EngineeringCoordinator,
//            Transitions = [
//                new ()
//                {
//                    Id = 300,
//                    Status = StatusEnum.AssignedToEngineerByCoordinator,
//                    Name = Keys.StateConsts.AssignedToEngineerByCoordinator,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.AssignToEngineer, ActionEnum.AssignToEngineer),
//                    Precondition = new Precondition(false, false, true)
//                },
//                new()
//                {
//                    Id = 101,
//                    Status = StatusEnum.ReturnedByCoordinatorForSalespersonReview,
//                    Name = Keys.StateConsts.ReturnedByCoordinatorForSalespersonReview,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.ReturnToSales, ActionEnum.ReturnToSales),
//                    Precondition = new Precondition(true, false, false)
//                }
//            ]
//        };

//    /// <summary>
//    /// When the engineer returns the offer request to the engineering coordinator for modifications, he can
//    /// - reassign to engineer or 
//    /// - return  to salesperson
//    /// </summary>
//    private static WorkflowStatus ReturnedByEngineerToCoordinatorForReassignState =>
//        new WorkflowStatus
//        {
//            Id = 201,
//            State = StateEnum.Returned,
//            Status = StatusEnum.ReturnedByEngineerToCoordinatorForReassign,
//            Name = Keys.StateConsts.ReturnedByEngineerToCoordinatorForReassign,
//            ActorRole = Keys.ActorConsts.EngineeringCoordinator,
//            Transitions = [
//                new()
//                {
//                    Id = 203,
//                    Status = StatusEnum.ReturnedByCoordinatorForSalespersonReview,
//                    Name = Keys.StateConsts.ReturnedByCoordinatorForSalespersonReview,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.ReturnToSales, ActionEnum.ReturnToSales),
//                    Precondition = new Precondition(true, false, false)
//                },
//                new()
//                {
//                    Id = 300,
//                    Status = StatusEnum.AssignedToEngineerByCoordinator,
//                    Name = Keys.StateConsts.AssignedToEngineerByCoordinator,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.AssignToEngineer, ActionEnum.AssignToEngineer),
//                    Precondition = new Precondition(false, false, true)
//                }
//            ]
//        };

//    /// <summary>
//    /// When the offer request is assigned to an engineer by the engineering coordinator
//    /// </summary>
//    private static WorkflowStatus AssignedToEngineerByCoordinatorState =>
//        new WorkflowStatus
//        {
//            Id = 300,
//            State = StateEnum.InProgress,
//            Status = StatusEnum.AssignedToEngineerByCoordinator,
//            Name = Keys.StateConsts.AssignedToEngineerByCoordinator,
//            ActorRole = Keys.ActorConsts.Engineer,
//            Transitions = [
//                new()
//                {
//                    Id = 400,
//                    Status = StatusEnum.AcceptedAssignmentByEngineer,
//                    Name = Keys.StateConsts.AcceptedAssignmentByEngineer,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.Accept, ActionEnum.Accept)
//                },
//                new()
//                {
//                    Id = 201,
//                    Status = StatusEnum.ReturnedByEngineerToCoordinatorForReassign,
//                    Name = Keys.StateConsts.ReturnedByEngineerToCoordinatorForReassign,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.ReturnToEngCoordinator, ActionEnum.ReturnToEngCoordinator),
//                    Precondition = new Precondition(true, false, false)
//                }
//            ]
//        };

//    /// <summary>
//    /// When the engineer accepts the offer request assignment
//    /// </summary>
//    private static WorkflowStatus AcceptedAssignmentByEngineerState =>
//        new WorkflowStatus
//        {
//            Id = 400,
//            State = StateEnum.InProgress,
//            Status = StatusEnum.AcceptedAssignmentByEngineer,
//            Name = Keys.StateConsts.AcceptedAssignmentByEngineer,
//            ActorRole = Keys.ActorConsts.Engineer,
//            Transitions = [
//                new()
//                {
//                    Id = 303,
//                    Status = StatusEnum.SubmittedByEngineerForReview,
//                    Name = Keys.StateConsts.SubmittedByEngineerForReview,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.SubmitForReview, ActionEnum.SubmitForReview)
//                }
//            ]
//        };

//    /// <summary>
//    /// When the engineer has submitted the offer for review to the engineering reviewer
//    /// </summary>
//    private static WorkflowStatus SubmittedByEngineerForReviewState =>
//        new WorkflowStatus
//        {
//            Id = 400,
//            State = StateEnum.InProgress,
//            Status = StatusEnum.SubmittedByEngineerForReview,
//            Name = Keys.StateConsts.SubmittedByEngineerForReview,
//            ActorRole = Keys.ActorConsts.EngineeringReviewer,
//            Transitions = [
//                new()
//                {
//                    Id = 401,
//                    Status = StatusEnum.ApprovedByEngineeringReviewer,
//                    Name = Keys.StateConsts.ApprovedByEngineeringReviewer,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.Approve, ActionEnum.Approve)
//                },
//                new()
//                {
//                    Id = 402,
//                    Status = StatusEnum.AssignedToEngineerByCoordinator,
//                    Name = Keys.StateConsts.AssignedToEngineerByCoordinator,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.Return, ActionEnum.Return),
//                    Precondition = new Precondition(true, false, false)
//                }
//            ]
//        };

//    /// <summary>
//    /// When the salesperson has returned the offer to engineering reviewer for modifications
//    /// </summary>
//    private static WorkflowStatus ReturnedBySalesToEngineeringReviewerState =>
//        new WorkflowStatus
//        {
//            Id = 403,
//            State = StateEnum.Returned,
//            Status = StatusEnum.ReturnedBySalesToEngineeringReviewer,
//            Name = Keys.StateConsts.ReturnedBySalesToEngineeringReviewer,
//            ActorRole = Keys.ActorConsts.EngineeringReviewer,
//            Transitions = [
//                new()
//                {
//                    Id = 500,
//                    Status = StatusEnum.ApprovedByEngineeringReviewer,
//                    Name = Keys.StateConsts.ApprovedByEngineeringReviewer,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.Approve, ActionEnum.Approve),
//                },
//                new()
//                {
//                    Id = 501,
//                    Status = StatusEnum.AssignedToEngineerByCoordinator,
//                    Name = Keys.StateConsts.AssignedToEngineerByCoordinator,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.Return, ActionEnum.Return),
//                    Precondition = new Precondition(true, false, false)
//                }
//            ]
//        };

//    /// <summary>
//    /// When the engineering reviewer has approved the offer
//    /// </summary>
//    private static WorkflowStatus ApprovedByEngineeringReviewerState =>
//        new WorkflowStatus
//        {
//            Id = 600,
//            State = StateEnum.InProgress,
//            Status = StatusEnum.ApprovedByEngineeringReviewer,
//            Name = Keys.StateConsts.ApprovedByEngineeringReviewer,
//            ActorRole = Keys.ActorConsts.Salesperson,
//            Transitions = [
//                new()
//                {
//                    Id = 601,
//                    Status = StatusEnum.QuotationInProgress,
//                    Name = Keys.StateConsts.QuotationInProgress,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.Accept, ActionEnum.Accept)
//                },
//                new()
//                {
//                    Id = 602,
//                    Status = StatusEnum.ReturnedBySalesToEngineeringReviewer,
//                    Name = Keys.StateConsts.ReturnedBySalesToEngineeringReviewer,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.Return, ActionEnum.Return),
//                    Precondition = new Precondition(true, false, false)
//                }
//            ]
//        };

//    /// <summary>
//    /// When the salesperson is working on the quotation
//    /// </summary>
//    private static WorkflowStatus QuotationInProgressState =>
//        new WorkflowStatus
//        {
//            Id = 700,
//            State = StateEnum.InProgress,
//            Status = StatusEnum.QuotationInProgress,
//            Name = Keys.StateConsts.QuotationInProgress,
//            ActorRole = Keys.ActorConsts.Salesperson,
//            Transitions = [
//                new()
//                {
//                    Id  = 800,
//                    Status = StatusEnum.Awarded,
//                    Name = Keys.StateConsts.Awarded,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.Awarded, ActionEnum.Awarded),
//                },
//                new()
//                {
//                    Id  = 801,
//                    Status = StatusEnum.Lost,
//                    Name = Keys.StateConsts.Lost,
//                    Action = new WorkflowAction(2, Keys.ActionConsts.Lost, ActionEnum.Lost),
//                }
//            ]
//        };

//    private static WorkflowStatus LostState =>
//        new WorkflowStatus
//        {
//            Id = 801,
//            State = StateEnum.Completed,
//            Status = StatusEnum.Lost,
//            Name = Keys.StateConsts.Lost,
//            ActorRole = Keys.ActorConsts.Salesperson,
//            Transitions = null
//        };

//    private static WorkflowStatus AwardedState =>
//        new WorkflowStatus
//        {
//            Id = 800,
//            State = StateEnum.Completed,
//            Status = StatusEnum.Awarded,
//            Name = Keys.StateConsts.Awarded,
//            ActorRole = Keys.ActorConsts.Salesperson,
//            Transitions = null
//        };
//}


