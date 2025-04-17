namespace DapperCrudPlayground.Core.Models;
public class ActionResult<T>
	where T : class
{
	public bool IsSuccess { get; set; }
	public T? Response { get; set; }
}
