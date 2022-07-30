using codigonaveia.academias.Domain.Entities.Account;
using codigonaveia.academias.Domain.Entities.EmailConfig;
using codigonaveia.academias.Infra.Data.DataConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace codigonaveia.academias.Infra.Data.Contexto
{
    public class DataContexto:IdentityDbContext<Users>
    {
        #region Table
        public DbSet<entidadeEmailConfiguracoes>? EmailConfiguracoes { get; set; }
        public DbSet<entidadeEmailAddress>? EmailAddress { get; set; }
        public DbSet<entidadeEmailPasswordAccount>? EmailPasswordAccount { get; set; }
        #endregion
        public DataContexto(DbContextOptions<DataContexto> options):base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>(new UsersConfiguration().Configure);
            builder.Entity<entidadeEmailAddress>(new EmailAddressConfiguration().Configure);
            builder.Entity<entidadeEmailConfiguracoes>(new EmailConfiguracoesConfiguration().Configure);
            builder.Entity<entidadeEmailPasswordAccount>(new EmailPasswordAccountConfiguration().Configure);
            base.OnModelCreating(builder);
        }
    }
}
