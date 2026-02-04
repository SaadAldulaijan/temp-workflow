using Microsoft.EntityFrameworkCore;
using WebApplication3.RequestManagement;
using WebApplication3.Workflows;
using static WebApplication3.Workflows.Keys;

namespace WebApplication3.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<OfferRequest> OfferRequests { get; set; }
    public DbSet<OfferRequestHistory> OfferRequestHistories { get; set; }

    // workflows 

    public DbSet<WorkflowStatus> WorkflowStatuses { get; set; }
    public DbSet<WorkflowTransition> WorkflowTransitions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureOfferRequests();
        modelBuilder.ConfigureWorkflows();
        //WorkflowSeeder.Seed(modelBuilder);
    }
}






//public static class WorkflowSeeder
//{
//    public static void Seed(ModelBuilder modelBuilder)
//    {
//        // 1. Seed Statuses
//        modelBuilder.Entity<WorkflowStatus>().HasData(
//            new WorkflowStatus { Id = StatusEnum.Drafted, StatusName = StateConsts.Drafted, State = StateEnum.InProgress, ActorRole = ActorConsts.Salesperson },
//            new WorkflowStatus { Id = StatusEnum.ReturnedByCoordinatorForSalespersonReview, StatusName = StateConsts.ReturnedByCoordinatorForSalespersonReview, State = StateEnum.Returned, ActorRole = ActorConsts.Salesperson },
//            new WorkflowStatus { Id = StatusEnum.SubmittedBySalesAndPendingEngineeringAssignment, StatusName = StateConsts.SubmittedBySalesAndPendingEngineeringAssignment, State = StateEnum.InProgress, ActorRole = ActorConsts.EngineeringCoordinator },
//            new WorkflowStatus { Id = StatusEnum.ReturnedByEngineerToCoordinatorForReassign, StatusName = StateConsts.ReturnedByEngineerToCoordinatorForReassign, State = StateEnum.Returned, ActorRole = ActorConsts.EngineeringCoordinator },
//            new WorkflowStatus { Id = StatusEnum.AssignedToEngineerByCoordinator, StatusName = StateConsts.AssignedToEngineerByCoordinator, State = StateEnum.InProgress, ActorRole = ActorConsts.Engineer },
//            new WorkflowStatus { Id = StatusEnum.AcceptedAssignmentByEngineer, StatusName = StateConsts.AcceptedAssignmentByEngineer, State = StateEnum.InProgress, ActorRole = ActorConsts.Engineer },
//            new WorkflowStatus { Id = StatusEnum.SubmittedByEngineerForReview, StatusName = StateConsts.SubmittedByEngineerForReview, State = StateEnum.InProgress, ActorRole = ActorConsts.EngineeringReviewer },
//            new WorkflowStatus { Id = StatusEnum.ReturnedBySalesToEngineeringReviewer, StatusName = StateConsts.ReturnedBySalesToEngineeringReviewer, State = StateEnum.Returned, ActorRole = ActorConsts.EngineeringReviewer },
//            new WorkflowStatus { Id = StatusEnum.ApprovedByEngineeringReviewer, StatusName = StateConsts.ApprovedByEngineeringReviewer, State = StateEnum.InProgress, ActorRole = ActorConsts.Salesperson },
//            new WorkflowStatus { Id = StatusEnum.QuotationInProgress, StatusName = StateConsts.QuotationInProgress, State = StateEnum.InProgress, ActorRole = ActorConsts.Salesperson },
//            new WorkflowStatus { Id = StatusEnum.Awarded, StatusName = StateConsts.Awarded, State = StateEnum.Completed, ActorRole = ActorConsts.Salesperson },
//            new WorkflowStatus { Id = StatusEnum.Lost, StatusName = StateConsts.Lost, State = StateEnum.Completed, ActorRole = ActorConsts.Salesperson }
//        );

//        var transitions = new[]
//        {
//            new { Id = 1, FromStatusId = StatusEnum.Drafted, ToStatusId = StatusEnum.SubmittedBySalesAndPendingEngineeringAssignment, Action = ActionEnum.Submit },
//            new { Id = 2, FromStatusId = StatusEnum.ReturnedByCoordinatorForSalespersonReview, ToStatusId = StatusEnum.SubmittedBySalesAndPendingEngineeringAssignment, Action = ActionEnum.Submit },
//            new { Id = 3, FromStatusId = StatusEnum.SubmittedBySalesAndPendingEngineeringAssignment, ToStatusId = StatusEnum.AssignedToEngineerByCoordinator, Action = ActionEnum.Assign },
//            new { Id = 4, FromStatusId = StatusEnum.SubmittedBySalesAndPendingEngineeringAssignment, ToStatusId = StatusEnum.ReturnedByCoordinatorForSalespersonReview, Action = ActionEnum.Return},
//            new { Id = 5, FromStatusId = StatusEnum.AssignedToEngineerByCoordinator, ToStatusId = StatusEnum.AcceptedAssignmentByEngineer, Action = ActionEnum.Accept },
//            new { Id = 6, FromStatusId = StatusEnum.AcceptedAssignmentByEngineer, ToStatusId = StatusEnum.SubmittedByEngineerForReview, Action = ActionEnum.Submit},
//            new { Id = 7, FromStatusId = StatusEnum.SubmittedByEngineerForReview, ToStatusId = StatusEnum.ApprovedByEngineeringReviewer, Action = ActionEnum.Approve },
//            new { Id = 8, FromStatusId = StatusEnum.ApprovedByEngineeringReviewer, ToStatusId = StatusEnum.QuotationInProgress, Action = ActionEnum.Accept },
//            new { Id = 9, FromStatusId = StatusEnum.QuotationInProgress, ToStatusId = StatusEnum.Awarded, Action = ActionEnum.Awarded },
//            new { Id = 10, FromStatusId = StatusEnum.QuotationInProgress, ToStatusId = StatusEnum.Lost, Action = ActionEnum.Lost }
//        };

//        modelBuilder.Entity<WorkflowTransition>().HasData(transitions);
//    }
//}

