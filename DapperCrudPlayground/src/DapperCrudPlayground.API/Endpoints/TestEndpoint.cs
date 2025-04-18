namespace DapperCrudPlayground.API.Endpoints;

public static class TestEndpoint
{
	public static void MapTestEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
	{
		endpointRouteBuilder.MapGet("/test", () =>
		{
			return TypedResults.Ok("test");
		}).WithName("Test")
		.WithOpenApi(x => new OpenApiOperation(x)
		{
			Summary = "Test Endpoint",
			Description = "A simple test endpoint used to verify the service is running.",
		});
	}
}
