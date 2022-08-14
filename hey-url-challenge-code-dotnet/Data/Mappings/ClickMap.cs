using hey_url_challenge_code_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hey_url_challenge_code_dotnet.Data.Mappings
{
    public class ClickMap : IEntityTypeConfiguration<Click>
    {
        public void Configure(EntityTypeBuilder<Click> builder)
        {
            //Table
            builder.ToTable("Click");

            //Primary Key
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

        }
    }
}