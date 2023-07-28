namespace PrevisaoDoTempoAPI.DTOs
{
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
