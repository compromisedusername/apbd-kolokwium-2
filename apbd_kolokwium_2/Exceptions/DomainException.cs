namespace apbd_kolokwium_2.Exceptions;


public class DomainException : Exception
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
}