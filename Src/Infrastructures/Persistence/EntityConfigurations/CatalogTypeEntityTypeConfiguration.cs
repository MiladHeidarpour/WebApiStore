﻿using Domain.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CatalogTypeEntityTypeConfiguration:IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> builder)
    {
        builder.ToTable("CatalogType");
        builder.Property(cb => cb.Type)
            .IsRequired()
            .HasMaxLength(100);
    }
}