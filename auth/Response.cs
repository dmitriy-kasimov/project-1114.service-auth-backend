using System.Text.Json;

namespace auth;

/*
 props of class Response in camel case because of contract response schema between all parts in each service
 */
public class Response<T>(bool Success, T? Data = null, string? Error = null) where T : class
{
    public bool success => Success;
    public T? data => Data;
    public string? error => Error;
    
    // public static string Serialize(Response<T> response)
    // {
    //     return JsonSerializer.Serialize(response);
    // }
    //
    // public static T? Deserialize(string json)
    // {
    //     return JsonSerializer.Deserialize<T>(json);
    // }
}