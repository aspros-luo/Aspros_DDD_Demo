using Aspros_DDD_Domain.UserItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aspros_DDD_Infrastructure.MapConfigurations.UserMapping
{
    public class UserMap : ModelBuilderExtenions.EntityMappingConfiguration<User>
    {
        public override void Map(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("users");
            entityTypeBuilder.HasKey(u => u.UserId);
            entityTypeBuilder.Property(u => u.UserId).IsRequired().HasColumnName("user_id").ValueGeneratedOnAdd();
            entityTypeBuilder.Property(u => u.AvatarUrl).HasMaxLength(128).HasColumnName("avatar_url");
            entityTypeBuilder.Property(u => u.Status);
            entityTypeBuilder.Property(u => u.UserType).HasColumnName("user_type");
            entityTypeBuilder.Property(u => u.LoginPwd).HasMaxLength(32).HasColumnName("login_pwd");
            entityTypeBuilder.Property(u => u.Mobile);
            entityTypeBuilder.Property(u => u.Email);
            entityTypeBuilder.Property(u => u.LoginName).HasMaxLength(32).HasColumnName("login_name");
            entityTypeBuilder.Property(u => u.LoginPwdEncryption).HasColumnName("login_pwd_encryption");
            entityTypeBuilder.Property(u => u.Nick);
            entityTypeBuilder.Property(u => u.LoginPwdSalt).HasMaxLength(50).HasColumnName("login_pwd_salt");
            entityTypeBuilder.Property(u => u.AccountType).HasColumnName("account_type");
            entityTypeBuilder.Property(u => u.GmtCreated).HasColumnName("gmt_created");
            entityTypeBuilder.Property(u => u.GmtModified).HasColumnName("gmt_modified");
            entityTypeBuilder.Ignore(u => u.Identitys);
            entityTypeBuilder.Ignore(u => u.ShippingAddress);
            entityTypeBuilder.Ignore(u => u.UserDetail);
            entityTypeBuilder.Ignore(u => u.Id);
            entityTypeBuilder.Ignore(u => u.UserSupplier);
        }
    }
}
