using codigonaveia.academias.Domain.Entities.EmailConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codigonaveia.academias.Infra.Data.DataConfig
{
    public class EmailPasswordAccountConfiguration : IEntityTypeConfiguration<entidadeEmailPasswordAccount>
    {
        public void Configure(EntityTypeBuilder<entidadeEmailPasswordAccount> builder)
        {
            builder.ToTable("EmailPasswordAccount");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Password)
                .HasColumnType("varchar(Max)")
                .IsRequired();
        }
    }
}
