namespace PrevisaoDoTempoAPI.DTOs
{
    public class RespostaErroAPIDTO
    {
        public bool Success => false;

        public int Code { get; set; }

        public string Message { get; set; }

        public RespostaErroAPIDTO(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
