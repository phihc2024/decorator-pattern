namespace Ecommerce.API.Application.Wrappers;

public class ServiceResponse<TData>
{
    public ServiceResponse(TData data, string message = "", bool succeeded = true, int statusCode = 200)
    {
        Succeeded = succeeded;
        UserMessage = message;
        Data = data;
        StatusCode = statusCode;
    }

    public ServiceResponse(string message, bool succeeded)
    {
        Succeeded = succeeded;
        UserMessage = message;
    }

    public bool Succeeded { get; set; }

    public string UserMessage { get; set; }

    public string SystemMessage { get; set; }

    public int StatusCode { get; set; }

    public List<string> Errors { get; set; }

    public TData Data { get; set; }
}