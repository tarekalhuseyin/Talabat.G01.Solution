
namespace Talabat.APIs.Errors
{
	public class ApiResponse
	{
		public int StatusCode { get; set; }
		public string Message { get; set; }

        public ApiResponse(int statusCode,string?message=null)
        {
            StatusCode = statusCode;
            Message =message??GetDefaultMessageForStatusCode(statusCode);
        }

		private string? GetDefaultMessageForStatusCode(int? statusCode)
		{
			return StatusCode switch
			{
				400 => "Bad request",
				401 => "you are not Authurized",
				404 => "resource not found ",
				500 => "internal server error",
				_ => null
			};
		}
	}
}
