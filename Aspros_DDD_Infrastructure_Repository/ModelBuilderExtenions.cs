using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aspros_DDD_Infrastructure
{
    public static class ModelBuilderExtenions
    {
        public static IEnumerable<Type> GetMappingTypes(this Assembly assembly, Type mappingInterface)
        {
            return
                assembly.GetTypes()
                    .Where(
                        t =>
                            !t.GetTypeInfo().IsAbstract &&
                            t.GetInterfaces()
                                .Any(
                                    i =>
                                        i.GetTypeInfo().IsGenericType &&
                                        i.GetGenericTypeDefinition() == mappingInterface));
        }

        public static void AddEntityConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var mappingTypes = assembly.GetMappingTypes(typeof(IEntityMappingConfiguration<>));
            foreach (var config in mappingTypes.Select(Activator.CreateInstance).Cast<IEntityMappingConfiguration>())
            {
                config.Map(modelBuilder);
            }
        }

        public interface IEntityMappingConfiguration
        {
            void Map(ModelBuilder modelBuilder);
        }

        public interface IEntityMappingConfiguration<T> : IEntityMappingConfiguration where T : class
        {
            void Map(EntityTypeBuilder<T> entityTypeBuilder);
        }

        public abstract class EntityMappingConfiguration<T> : IEntityMappingConfiguration<T> where T : class
        {
            public abstract void Map(EntityTypeBuilder<T> entityTypeBuilder);

            public void Map(ModelBuilder modelBuilder)
            {
                Map(modelBuilder.Entity<T>());
            }
        }
    }
}
