namespace codigonaveia.academias.Domain.Entities.EmailConfig
{
    public class entidadeEmailConfiguracoes
    {
        public int Id { get; set; }
        public string? Smtp { get; set; }
        public int Port { get; set; }
        public string? EmailUser { get; set; }

    }
}
