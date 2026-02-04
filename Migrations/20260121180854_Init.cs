using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    StatusName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    ActorRole = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferRequestHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfferRequestId = table.Column<int>(type: "integer", nullable: false),
                    PreviousStatus = table.Column<string>(type: "text", nullable: false),
                    ActionTaken = table.Column<string>(type: "text", nullable: false),
                    NewStatus = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferRequestHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferRequestHistories_OfferRequests_OfferRequestId",
                        column: x => x.OfferRequestId,
                        principalTable: "OfferRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowTransitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromStatusId = table.Column<int>(type: "integer", nullable: false),
                    ToStatusId = table.Column<int>(type: "integer", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    Precondition = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowTransitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowTransitions_WorkflowStatuses_FromStatusId",
                        column: x => x.FromStatusId,
                        principalTable: "WorkflowStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkflowTransitions_WorkflowStatuses_ToStatusId",
                        column: x => x.ToStatusId,
                        principalTable: "WorkflowStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "WorkflowStatuses",
                columns: new[] { "Id", "ActorRole", "State", "StatusName" },
                values: new object[,]
                {
                    { 100, "salesperson", "InProgress", "Drafted" },
                    { 101, "salesperson", "Returned", "ReturnedByCoordinatorForSalespersonReview" },
                    { 200, "engineering-coordinator", "InProgress", "SubmittedBySalesAndPendingEngineeringAssignment" },
                    { 201, "engineering-coordinator", "Returned", "ReturnedByEngineerToCoordinatorForReassign" },
                    { 300, "engineer", "InProgress", "AssignedToEngineerByCoordinator" },
                    { 400, "engineer", "InProgress", "AcceptedAssignmentByEngineer" },
                    { 500, "engineering-reivewer", "InProgress", "SubmittedByEngineerForReview" },
                    { 600, "salesperson", "InProgress", "ApprovedByEngineeringReviewer" },
                    { 601, "engineering-reivewer", "Returned", "ReturnedBySalesToEngineeringReviewer" },
                    { 700, "salesperson", "InProgress", "QuotationInProgress" },
                    { 800, "salesperson", "Completed", "Awarded" },
                    { 801, "salesperson", "Completed", "Lost" }
                });

            migrationBuilder.InsertData(
                table: "WorkflowTransitions",
                columns: new[] { "Id", "Action", "FromStatusId", "ToStatusId" },
                values: new object[,]
                {
                    { 1, "SubmitToEngineering", 100, 200 },
                    { 2, "SubmitToEngineering", 101, 200 },
                    { 3, "AssignToEngineer", 200, 300 },
                    { 4, "ReturnToSales", 200, 101 },
                    { 5, "Accept", 300, 400 },
                    { 6, "SubmitForReview", 400, 500 },
                    { 7, "Approve", 500, 600 },
                    { 8, "Accept", 600, 700 },
                    { 9, "Awarded", 700, 800 },
                    { 10, "Lost", 700, 801 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferRequestHistories_OfferRequestId",
                table: "OfferRequestHistories",
                column: "OfferRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowTransitions_FromStatusId",
                table: "WorkflowTransitions",
                column: "FromStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowTransitions_ToStatusId",
                table: "WorkflowTransitions",
                column: "ToStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferRequestHistories");

            migrationBuilder.DropTable(
                name: "WorkflowTransitions");

            migrationBuilder.DropTable(
                name: "OfferRequests");

            migrationBuilder.DropTable(
                name: "WorkflowStatuses");
        }
    }
}
