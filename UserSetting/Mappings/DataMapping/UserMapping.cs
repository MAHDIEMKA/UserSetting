using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserSetting.Models;

namespace UserSetting.Mappings.DataMapping
{
    public class UserMapping : IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.UserName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.IsRemoved).HasColumnName("IsRemoved");
            
        }
    }
}
