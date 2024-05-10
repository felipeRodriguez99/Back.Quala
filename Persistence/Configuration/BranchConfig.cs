using Domain.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Quala.Branches");

            builder.HasKey(x => new { x.Code });

            builder.Property(x => x.Code)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
            .HasMaxLength(250)
            .IsRequired();

            builder.Property(p => p.Address)
            .HasMaxLength(250)
            .IsRequired();

            builder.Property(p => p.Identifications)
            .HasMaxLength(50)
            .IsRequired();

            builder.HasOne<Currency>() 
            .WithMany(c => c.Branches)
            .HasForeignKey(x => x.CurrencyId);

        }
    }
}
