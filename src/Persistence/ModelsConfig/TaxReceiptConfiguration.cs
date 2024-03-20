using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;

namespace Persistence.ModelsConfig
{

    internal class TaxReceiptConfiguration : IEntityTypeConfiguration<TaxReceipt>
    {
        public void Configure(EntityTypeBuilder<TaxReceipt> builder)
        {

            builder.ToTable("TaxReceipts");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.RncCedula)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.NCF)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Monto)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(t => t.Itbis18)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

        }
    }
}