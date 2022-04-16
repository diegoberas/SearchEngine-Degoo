using Degoo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Degoo.EntityConfigurations
{
    public class LinkConfiguration : EntityTypeConfiguration<Link>
    {
        public LinkConfiguration()
        {
            ToTable("Link");

            HasKey(l => l.Id);

            Property(l => l.Url)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnType("varchar");
        }

    }
}