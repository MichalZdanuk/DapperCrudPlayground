using System.Net;

namespace DapperCrudPlayground.Core.Models;
public class ActionResult<T>
	where T : class
{
	public ActionResult(bool isSuccess, HttpStatusCode statusCode, T? response)
	{
		IsSuccess = isSuccess;
		StatusCode = statusCode;
		Response = response;
	}

	public bool IsSuccess { get; set; }
	public HttpStatusCode StatusCode { get; set; }
	public T? Response { get; set; }

	public static ActionResult<T> Success(T response) =>
		new(true, HttpStatusCode.OK, response);

	public static ActionResult<T> Fail(HttpStatusCode statusCode) =>
		new(false, statusCode, null);
}
