﻿using Dapper;
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

	public Task<ActionResult<Movie>> DeleteAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<IEnumerable<Movie>>> GetAllAsync()
	{
		throw new NotImplementedException();
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

	public Task<ActionResult<Movie>> UpdateAsync(Guid id, Movie movie)
	{
		throw new NotImplementedException();
	}
}
