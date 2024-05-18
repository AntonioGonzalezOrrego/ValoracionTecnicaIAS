namespace IAS.API.Errors
{
  public class CodeErrorResponse
  {
    public int StatusCode { get; set; }
    public string? Message { get; set; } = string.Empty;

    public CodeErrorResponse(int statusCode, string? message = null)
    {
      StatusCode = statusCode;
      Message = message ?? GetDefaultMessageStatudCode(statusCode);
    }

    private string GetDefaultMessageStatudCode(int statusCode)
    {
      return statusCode switch
      {
        400 => "El request tiene errores",
        401 => "No tiene autorización",
        404 => "No se encontró el recurso solicitado",
        500 => "Errores en el servidor",
        _ => string.Empty,
      };
    }
  }
}
