using codigonaveia.academias.Domain.Entities.Alunos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace codigonaveia.academias.Infra.Data.DataConfig
{
    public class AlunosConfiguration : IEntityTypeConfiguration<entidadeAlunos>
    {
        public void Configure(EntityTypeBuilder<entidadeAlunos> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(x => x.IdAlunos);

            builder.Property(x => x.CPF)
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(x => x.Celular)
               .HasColumnType("varchar(11)")
               .IsRequired();

            builder.Property(x => x.Email)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(x => x.Cep)
              .HasColumnType("varchar(20)")
              .IsRequired();

            builder.Property(x => x.Logradouro)
              .HasColumnType("varchar(100)")
              .IsRequired();

            builder.Property(x => x.Complemento)
              .HasColumnType("varchar(100)")
              .IsRequired();

            builder.Property(x => x.Bairro)
              .HasColumnType("varchar(100)")
              .IsRequired();

            builder.Property(x => x.Cidade)
              .HasColumnType("varchar(100)")
              .IsRequired();

            builder.Property(x => x.Uf)
              .HasColumnType("varchar(2)")
              .IsRequired();

            builder.HasOne(x => x.Users)
                 .WithOne(x => x.Alunos)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade)
                 .HasForeignKey<entidadeAlunos>(x=>x.UserId);
        }
    }
}
