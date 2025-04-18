using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCore(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/test", () =>
{
    return TypedResults.Ok("test");
});

app.MapPost("/movies", async (IMovieService movieService, CreateMovieDto createMovieDto) =>
{
	var result = await movieService.AddAsync(createMovieDto);
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
}).WithName("CreateMovie")
.WithOpenApi(x => new OpenApiOperation(x)
{
	Summary = "Create Movie",
	Description = "Creates a new movie record in the database using the provided details.",
});

app.MapGet("/movies/{id}", async (IMovieService movieService, Guid id) =>
{
	var result = await movieService.GetByIdAsync(id);
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
}).WithName("GetMovie")
.WithOpenApi(x => new OpenApiOperation(x)
{
	Summary = "Get Movie by ID",
	Description = "Retrieves a movie by its unique identifier. Returns basic movie information.",
});

app.MapGet("/movies", async (IMovieService movieService) =>
{
	var result = await movieService.GetAllAsync();
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
}).WithName("BrowseMovies")
.WithOpenApi(x => new OpenApiOperation(x)
{
	Summary = "Browse Movies",
	Description = "Retrieves a list of all movies currently stored in the database.",
});
app.MapGet("/movies/{id}/details", async (IMovieService movieService, Guid id) =>
{
	var result = await movieService.GetDetailsAsync(id);
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
}).WithName("GetMovieDetails")
.WithOpenApi(x => new OpenApiOperation(x)
{
	Summary = "Get Movie Details",
	Description = "Fetches detailed information about a specific movie, including additional metadata or related data.",
});

app.MapDelete("/movies/{id}", async (IMovieService movieService, Guid id) =>
{
	var result = await movieService.DeleteAsync(id);
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
}).WithName("DeleteMovie")
.WithOpenApi(x => new OpenApiOperation(x)
{
	Summary = "Delete Movie",
	Description = "Deletes the movie with the specified ID from the database."
});

app.MapPut("/movies/{id}", async (IMovieService movieService, Guid id, UpdateMovieDto updateMovieDto) =>
{
	var result = await movieService.UpdateAsync(id, updateMovieDto);
	return ActionResultToResponseMapper.GetResponseResultFromActionResult(result);
}).WithName("UpdateMovie")
.WithOpenApi(x => new OpenApiOperation(x)
{
	Summary = "Update Movie",
	Description = "Updates an existing movie's details using the provided data and ID.",
});

app.Run();
