using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.SaleNumber).IsRequired().HasMaxLength(20);
        builder.HasIndex(s => s.SaleNumber).IsUnique();

        builder.Property(s => s.CustomerId).HasColumnType("uuid").IsRequired();

        builder.Property(s => s.CustomerName).IsRequired().HasMaxLength(200);

        builder.Property(s => s.Branch).IsRequired().HasMaxLength(100);

        builder.Ignore(s => s.TotalAmount);

        builder.Property(s => s.Date).IsRequired();

        builder.Property(s => s.Cancelled).IsRequired().HasDefaultValue(false);

        builder.HasMany(s => s.Items).WithOne().HasForeignKey(si => si.SaleId).OnDelete(DeleteBehavior.Cascade);
    }
}
