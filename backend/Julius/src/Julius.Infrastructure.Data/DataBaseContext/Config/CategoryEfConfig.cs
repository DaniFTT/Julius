using Julius.Domain.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Julius.Infrastructure.Data.DataBaseContext.Config;

public class CategoryEFConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Type)
            .IsRequired()
            .HasConversion(
                p => p.Value,
                p => CategoryType.FromValue(p));

        builder.Property(p => p.UserId)
            .IsRequired();
    }
}

