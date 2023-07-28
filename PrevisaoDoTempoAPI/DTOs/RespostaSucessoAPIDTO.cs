namespace PrevisaoDoTempoAPI.DTOs
{
    /// <summary>
    /// Retorna as respostas bem-sucedidas da API.
    /// </summary>
    public class RespostaSucessoAPIDTO
    {
        public bool Success => true;

        public int Code { get; set; }

        public string Message { get; set; }

        public RespostaSucessoAPIDTO(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }

    /// <summary>
    /// Retorna as respostas bem-sucedidas da API, com dados adicionais.
    /// </summary>
    /// <typeparam name="TData">Tipo de dado a ser retornado.</typeparam>
    public class RespostaSucessoAPIDTO<TData>
    {
        public bool Success => true;

        public int Code { get; set; }

        public string Message { get; set; }

        public TData Data { get; set; }

        public RespostaSucessoAPIDTO(int code, string message, TData data)
        {
            Code = code;
            Message = message;
            Data = data;
        }
    }
}
