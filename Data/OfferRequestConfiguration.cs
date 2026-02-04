using Microsoft.EntityFrameworkCore;
using WebApplication3.RequestManagement;

namespace WebApplication3.Data;

public static class OfferRequestConfiguration
{
    public static void ConfigureOfferRequests(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OfferRequest>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Status).HasConversion<string>().IsRequired();
            entity.Property(e => e.State).HasConversion<string>().IsRequired();
        });


        modelBuilder.Entity<OfferRequestHistory>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.PreviousStatus).HasConversion<string>().IsRequired();

            entity.Property(e => e.ActionTaken).HasConversion<string>().IsRequired();

            entity.Property(e => e.NewStatus).HasConversion<string>().IsRequired();

            entity.Property(e => e.CreationTime).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");

        });
    }
}