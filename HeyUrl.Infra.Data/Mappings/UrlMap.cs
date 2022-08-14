using HeyUrl.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeyUrl.Infra.Data.Mappings
{
    public class UrlMap : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            //Table
            builder.ToTable("Url");

            //Primary Key
            builder.HasKey(x => x.Id);

            //Properties
            builder.Property(x => x.ShortUrl)
                .IsRequired()
                .HasColumnName("ShortUrl")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            //Properties
            builder.Property(x => x.Count)
                .IsRequired()
                .HasColumnName("Count")
                .HasColumnType("INT");
        }
    }
}
