namespace DapperCrudPlayground.Core.Models;
public class ActionResult<T>
	where T : class
{
	public ActionResult(bool isSuccess, T? response)
	{
		IsSuccess = isSuccess;
		Response = response;
	}

	public bool IsSuccess { get; set; }
	public T? Response { get; set; }
}
