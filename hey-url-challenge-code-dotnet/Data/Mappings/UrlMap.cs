using hey_url_challenge_code_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hey_url_challenge_code_dotnet.Data.Mappings
{
    public class UrlMap : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            //Table
            builder.ToTable("Url");

            //Primary Key
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Properties
            builder.Property(x => x.ShortUrl)
                .IsRequired()
                .HasColumnName("ShortUrl")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.OriginalUrl)
                .IsRequired()
                .HasColumnName("OriginalUrl")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Count)
                .IsRequired()
                .HasColumnName("Count")
                .HasColumnType("INT");

            //Relationships
            builder.HasMany(u => u.Clicks)
                    .WithOne()
                    .HasForeignKey(c => c.IdUrl);
        }
    }
}
