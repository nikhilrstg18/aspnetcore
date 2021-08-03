using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Project.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e=>e.Name).IsRequired().HasMaxLength(50);
        }
    }
}
