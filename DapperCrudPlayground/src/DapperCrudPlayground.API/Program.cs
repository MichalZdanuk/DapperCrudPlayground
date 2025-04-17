using DapperCrudPlayground.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCore();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/test", () =>
{
    return TypedResults.Ok("test");
});

app.Run();
