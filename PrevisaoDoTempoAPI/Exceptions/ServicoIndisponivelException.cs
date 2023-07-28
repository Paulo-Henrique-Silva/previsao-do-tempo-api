namespace PrevisaoDoTempoAPI.Exceptions
{
    public class ServicoIndisponivelException : Exception
    {
        public ServicoIndisponivelException(string? message) : base(message)
        {
        }
    }
}
