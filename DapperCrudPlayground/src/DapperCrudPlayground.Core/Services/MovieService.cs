using Dapper;
using DapperCrudPlayground.Core.Database;
using DapperCrudPlayground.Core.Models;

namespace DapperCrudPlayground.Core.Services;
public class MovieService(IDbConnectionFactory connectionFactory)
	: IMovieService
{
	public async Task<ActionResult<Movie>> AddAsync(Movie movie)
	{
		using var dbConnection = await connectionFactory.CreateConnectionAsync();
		await dbConnection.ExecuteAsync(
			"""
			INSERT INTO movies (id, title, releaseYear)
			VALUES (@Id, @Title, @ReleaseYear)
			""", movie);

		return new ActionResult<Movie>(true, null);
	}

	public async Task<ActionResult<Movie>> DeleteAsync(Guid id)
	{
		using var dbConnection = await connectionFactory.CreateConnectionAsync();
		var result = await dbConnection.ExecuteAsync("DELETE FROM movies WHERE Id=@id", new { id });

		return new ActionResult<Movie>(result > 0, null);
	}

	public async Task<ActionResult<IEnumerable<Movie>>> GetAllAsync()
	{
		using var dbConnection = await connectionFactory.CreateConnectionAsync();
		var movies = await dbConnection.QueryAsync<Movie>("SELECT * FROM movies");

		return new ActionResult<IEnumerable<Movie>>(true, movies);
	}

	public async Task<ActionResult<Movie>> GetByIdAsync(Guid id)
	{
		using var dbConnection = await connectionFactory.CreateConnectionAsync();
		var movie = await dbConnection.QuerySingleOrDefaultAsync<Movie>(
			"""
			SELECT * FROM movies WHERE Id=@id
			""", new { id });

		return new ActionResult<Movie>(true,  movie);
	}

	public async Task<ActionResult<Movie>> UpdateAsync(Guid id, Movie movie)
	{
		using var dbConntection = await connectionFactory.CreateConnectionAsync();
		var existingMovie = await dbConntection.QuerySingleOrDefaultAsync<Movie>(
			"""
			SELECT * FROM movies WHERE Id=@id
			""", new { id });

		if (existingMovie is null)
		{
			return new ActionResult<Movie>(false, null);
		}

		await dbConntection.ExecuteAsync(
			"""
			UPDATE movies SET Title=@Title, ReleaseYear=@ReleaseYear WHERE Id=@Id
			""", movie);

		return new ActionResult<Movie>(true, null);
	}
}
