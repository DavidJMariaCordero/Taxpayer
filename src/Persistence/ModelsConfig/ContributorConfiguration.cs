using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.ModelsConfig
{

    internal class ContributorConfiguration : IEntityTypeConfiguration<Contributor>
    {
        public void Configure(EntityTypeBuilder<Contributor> builder)
        {

            builder.ToTable("Contributors");

            builder.HasKey(c => c.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.RncCedula)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Tipo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Estatus)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}