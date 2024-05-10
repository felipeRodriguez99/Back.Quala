using Domain.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class CurrencyConfig : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Quala.Currencies");

            builder.HasKey(x => new { x.Id });

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
            .HasMaxLength(250)
            .IsRequired();

            builder.Property(p => p.Abbreviation)
            .HasMaxLength(10)
            .IsRequired();

            builder.HasData(
              new Currency { Id = 1, Description = "Dólar estadounidense", Abbreviation = "USD" },
              new Currency { Id = 2, Description = "Euro", Abbreviation = "EUR" },
              new Currency { Id = 3, Description = "Peso colombiano", Abbreviation = "COP" },
              new Currency { Id = 4, Description = "Peso mexicano", Abbreviation = "MXN" }
              );
        }
    }
}
