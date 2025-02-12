namespace webcarsAPI.Comunicacao.Requests.Veiculos
{
    public class RequestAdicionaVeiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string Chassi { get; set; }
        public string Renavam { get; set; }
        public string Combustivel { get; set; }
        public string Quilometragem { get; set; }
        public string Descricao { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public string UsuarioId { get; set; }
    }
}
