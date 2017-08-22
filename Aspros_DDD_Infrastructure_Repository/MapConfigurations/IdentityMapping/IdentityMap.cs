using Aspros_DDD_Domain.IdentityItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aspros_DDD_Infrastructure_Repository.MapConfigurations.IdentityMapping
{
    public class IdentityMap : ModelBuilderExtenions.EntityMappingConfiguration<Identity>
    {
        public override void Map(EntityTypeBuilder<Identity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("identities");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.Name);
        }
    }
}
