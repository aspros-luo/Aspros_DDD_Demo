using Aspros_DDD_Domain.IdentityItem;
using Aspros_DDD_Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Aspros_DDD_Infrastructure_Repository.MapConfigurations.IdentityMapping
{
    public class IdentityMap : ModelBuilderExtenions.EntityMappingConfiguration<Identity>
    {
        public override void Map(EntityTypeBuilder<Identity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Identities");
            entityTypeBuilder.HasKey(i => i.Id);
            entityTypeBuilder.Property(i => i.Id).ValueGeneratedOnAdd();
            entityTypeBuilder.Property(i => i.Name);
        }
    }
}
