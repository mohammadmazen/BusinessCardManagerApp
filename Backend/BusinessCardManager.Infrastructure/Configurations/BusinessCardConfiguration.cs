using BusinessCardManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardManager.Domain.Interfaces.Configurations;
public class BusinessCardConfiguration : IEntityTypeConfiguration<BusinessCard>
{
    public void Configure(EntityTypeBuilder<BusinessCard> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.Gender)
            .IsRequired();

        entity.Property(e => e.DateOfBirth)
            .IsRequired();

        entity.Property(e => e.Email)
            .IsRequired();

        entity.Property(e => e.Phone)
            .IsRequired();

        entity.Property(e => e.PhotoBase64)
            .IsRequired();

        entity.Property(e => e.Address)
            .IsRequired()
            .HasMaxLength(200);
    }
}
