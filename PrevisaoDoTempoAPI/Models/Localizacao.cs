namespace PrevisaoDoTempoAPI.Models
{
    /// <summary>
    /// Encapsula os dados da API ViaCEP.
    /// </summary>
    public class Localizacao
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Localidade { get; set; }

        public string Uf { get; set; }

        public string Ibge { get; set; }

        public string Gia { get; set; }

        public string Ddd { get; set; }

        public string Siafi { get; set; }

        public Localizacao(string cep, string logradouro, string complemento, string bairro, 
            string localidade, string uf, string ibge, string gia, string ddd, string siafi)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
            Ibge = ibge;
            Gia = gia;
            Ddd = ddd;
            Siafi = siafi;
        }
    }
}
