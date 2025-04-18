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

app.MapGet("/movies/{id}/details", async (IMovieService movieService, Guid id) =>
{
	var result = await movieService.GetDetailsAsync(id);
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
