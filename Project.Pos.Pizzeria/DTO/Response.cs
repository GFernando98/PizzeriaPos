namespace Project.Pos.Pizzeria.WebApi.DTO;

public class Response<T>
{
    public int StatusCode { get; set; }
    public T? Entity { get; set; }
    public string? Message { get; set; }
    public string? Error { get; set; }
}