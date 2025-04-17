using DapperCrudPlayground.Core.Models;
using System.Net;

namespace DapperCrudPlayground.API;

public static class ActionResultToResponseMapper
{
	public static IResult GetResponseResultFromActionResult<T>(ActionResult<T> actionResult) where T : class
	{
		return actionResult.StatusCode switch
		{
			HttpStatusCode.OK when actionResult.IsSuccess => Results.Ok(actionResult.Response),
			HttpStatusCode.Created when actionResult.IsSuccess => Results.Created(string.Empty, actionResult.Response),
			HttpStatusCode.NotFound => Results.NotFound(),
			HttpStatusCode.BadRequest => Results.BadRequest(),
			_ => Results.StatusCode((int)actionResult.StatusCode)
		};
	}
}
