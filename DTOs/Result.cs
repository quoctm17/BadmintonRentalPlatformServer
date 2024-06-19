using System.Net;

namespace DTOs;

public class Result<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public Result()
    {
    }
}