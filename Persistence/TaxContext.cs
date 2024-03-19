using Microsoft.EntityFrameworkCore;
using Persistence.ModelsConfig;

namespace Persistence
{

    public partial class TaxContext : DbContext
    {

        public TaxContext()
        {
        }


        public TaxContext(DbContextOptions<TaxContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_Pref_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new ContributorConfiguration());
            modelBuilder.ApplyConfiguration(new TaxReceiptConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}