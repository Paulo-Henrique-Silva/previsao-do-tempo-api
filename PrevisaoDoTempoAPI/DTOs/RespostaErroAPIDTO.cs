namespace PrevisaoDoTempoAPI.DTOs
{
    /// <summary>
    /// Retorna as respostas mal-sucedidas da API.
    /// </summary>
    public class RespostaErroAPIDTO
    {
        public bool Success => false;

        public int Code { get; set; }

        public string Message { get; set; }

        public static RespostaErroAPIDTO RespostaErro500 => new(500, "Um erro inesperado aconteceu.");

        public RespostaErroAPIDTO(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
