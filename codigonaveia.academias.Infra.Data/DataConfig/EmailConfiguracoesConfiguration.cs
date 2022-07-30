using codigonaveia.academias.Domain.Entities.EmailConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codigonaveia.academias.Infra.Data.DataConfig
{
    public class EmailConfiguracoesConfiguration : IEntityTypeConfiguration<entidadeEmailConfiguracoes>
    {
        public void Configure(EntityTypeBuilder<entidadeEmailConfiguracoes> builder)
        {
            builder.ToTable("EmailConfiguracoes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Smtp)
             .HasColumnType("varchar(100)")
             .IsRequired();

            builder.Property(x => x.Port)
                .IsRequired();

            builder.Property(x => x.EmailUser)
            .HasColumnType("varchar(100)")
            .IsRequired();
        }
    }
}
