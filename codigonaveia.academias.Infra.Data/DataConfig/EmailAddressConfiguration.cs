using codigonaveia.academias.Domain.Entities.EmailConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codigonaveia.academias.Infra.Data.DataConfig
{
    public class EmailAddressConfiguration : IEntityTypeConfiguration<entidadeEmailAddress>
    {
        public void Configure(EntityTypeBuilder<entidadeEmailAddress> builder)
        {
            builder.ToTable("EmailAddress");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.From)
             .HasColumnType("varchar(100)")
             .IsRequired();

            builder.Property(x => x.To)
             .HasColumnType("varchar(100)")
             .IsRequired();

            builder.Property(x => x.Subject)
             .HasColumnType("varchar(500)")
             .IsRequired();

            builder.Property(x => x.Body)
             .HasColumnType("varchar(500)")
             .IsRequired();
        }
    }
    
  
}
