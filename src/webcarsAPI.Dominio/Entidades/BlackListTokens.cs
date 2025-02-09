namespace webcarsAPI.Dominio.Entidades
{
    public class BlackListTokens
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public DateTime Expiracao { get; set; }
    }
}
