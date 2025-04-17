using DapperCrudPlayground.Core;
using DapperCrudPlayground.Core.DTO;
using DapperCrudPlayground.Core.Models;
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
	var creationResult = await movieService.AddAsync(createMovieDto);

	if (!creationResult.IsSuccess)
	{
		return Results.BadRequest();
	}

	return Results.Created();
});

app.MapGet("/movies/{id}", async (IMovieService movieService, Guid id) =>
{
	var result = await movieService.GetByIdAsync(id);

	if (result is null)
	{
		return Results.NotFound();
	}

	return Results.Ok(result.Response);
});

app.MapGet("/movies", async (IMovieService movieService) =>
{
	var result = await movieService.GetAllAsync();

	return Results.Ok(result.Response);
});

app.MapDelete("/movies/{id}", async (IMovieService movieService, Guid id) =>
{
	var result = await movieService.DeleteAsync(id);

	if (!result.IsSuccess)
	{
		return Results.BadRequest();
	}

	return Results.Accepted();
});

app.MapPut("/movies/{id}", async (IMovieService movieService, Guid id, Movie movie) =>
{
	var result = await movieService.UpdateAsync(id, movie);

	if (!result.IsSuccess)
	{
		return Results.BadRequest();
	}

	return Results.Accepted();
});

app.Run();
