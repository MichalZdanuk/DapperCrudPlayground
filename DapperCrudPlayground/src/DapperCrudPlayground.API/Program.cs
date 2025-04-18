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

app.MapTestEndpoint();
app.MapMoviesEndpoints();

app.Run();
