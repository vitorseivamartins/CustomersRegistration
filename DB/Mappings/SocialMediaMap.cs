using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DB.Mappings
{
    public class SocialMediaMap : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedia");
            builder.HasKey(c => c.idSocialMedia);

            builder.Property(c => c.idSocialMedia).HasColumnName("idSocialMedia").ValueGeneratedOnAdd();
            builder.Property(c => c.Identification).HasColumnName("Identification");
            builder.Property(c => c.SocialMediaLink).HasColumnName("SocialMediaLink");

            //builder.HasOne(c => c.Customer).WithMany(p => p.SocialMedias);
        }
    }
}
