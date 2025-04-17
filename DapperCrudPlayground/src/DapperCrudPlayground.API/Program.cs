using DapperCrudPlayground.API;
using DapperCrudPlayground.Core;
using DapperCrudPlayground.Core.DTO;
using DapperCrudPlayground.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCore(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/test", () =>
{
    return TypedResults.Ok("test");
});

app.MapPost("/movies", async (IMovieService movieService, CreateMovieDto createMovieDto) =>
{
	var result = await movieService.AddAsync(createMovieDto);
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
});

app.MapGet("/movies/{id}", async (IMovieService movieService, Guid id) =>
{
	var result = await movieService.GetByIdAsync(id);
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
});

app.MapGet("/movies", async (IMovieService movieService) =>
{
	var result = await movieService.GetAllAsync();
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
});

app.MapDelete("/movies/{id}", async (IMovieService movieService, Guid id) =>
{
	var result = await movieService.DeleteAsync(id);
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
});

app.MapPut("/movies/{id}", async (IMovieService movieService, Guid id, UpdateMovieDto updateMovieDto) =>
{
	var result = await movieService.UpdateAsync(id, updateMovieDto);
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
});

app.Run();
