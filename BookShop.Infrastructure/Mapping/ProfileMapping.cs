using BookShop.Domain.Models.Profile;
using BookShop.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Mapping
{
    public class ProfileMapping : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile").HasKey(p => p.UserId);
            builder.Property(p => p.UserName).HasMaxLength(70).IsRequired();
            builder.Property(p => p.NationalId).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(150).IsRequired();
            builder.HasOne<User>(u => u.User).WithOne(p => p.Profile).HasForeignKey<User>(u => u.Id);
        }
    }
}
