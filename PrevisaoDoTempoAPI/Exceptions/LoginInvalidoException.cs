namespace PrevisaoDoTempoAPI.Exceptions
{
    public class LoginInvalidoException : Exception
    {
        public LoginInvalidoException(string? message) : base(message)
        {
        }
    }
}
