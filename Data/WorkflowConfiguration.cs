using Microsoft.EntityFrameworkCore;
using WebApplication3.Workflows;

namespace WebApplication3.Data;

public static class WorkflowConfiguration
{
    public static void ConfigureWorkflows(this ModelBuilder modelBuilder)
    {
        // --- WorkflowStatus Configuration ---
        modelBuilder.Entity<WorkflowStatus>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.StatusName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ActorRole).IsRequired().HasMaxLength(100);

            entity.Property(e => e.State).HasConversion<string>();
        });

        // --- WorkflowTransition Configuration ---
        modelBuilder.Entity<WorkflowTransition>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Action).HasConversion<string>();

            // Navigation
            entity.HasOne(d => d.FromStatus)
                  .WithMany(p => p.Transitions)
                  .HasForeignKey(d => d.FromStatusId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.ToStatus)
                  .WithMany()
                  .HasForeignKey(d => d.ToStatusId)
                  .OnDelete(DeleteBehavior.Restrict);

            // MAP TO JSON COLUMN
            entity.OwnsOne(t => t.Precondition, builder =>
            {
                builder.ToJson(); // This is the magic line for EF Core 7+
            });
        });
    }
}
