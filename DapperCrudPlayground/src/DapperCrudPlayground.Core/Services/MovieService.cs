﻿using Dapper;
using DapperCrudPlayground.Core.Database;
using DapperCrudPlayground.Core.DTO;
using DapperCrudPlayground.Core.Models;
using Mapster;
using System.Net;

namespace DapperCrudPlayground.Core.Services;
public class MovieService(IDbConnectionFactory connectionFactory)
	: IMovieService
{
	public async Task<ActionResult<Movie>> AddAsync(CreateMovieDto createMovieDto)
	{
		using var dbConnection = await connectionFactory.CreateConnectionAsync();
		await dbConnection.ExecuteAsync(
			"""
			INSERT INTO movies (id, title, director, releaseYear)
			VALUES (@Id, @Title, @Director, @ReleaseYear)
			""", new { id = Guid.NewGuid(), Title = createMovieDto.Title, Director = createMovieDto.Director, ReleaseYear = createMovieDto.ReleaseYear });

		return new ActionResult<Movie>(true, HttpStatusCode.Created, null);
	}

	public async Task<ActionResult<Movie>> DeleteAsync(Guid id)
	{
		using var dbConnection = await connectionFactory.CreateConnectionAsync();
		var result = await dbConnection.ExecuteAsync("DELETE FROM movies WHERE Id=@id", new { id });

		return result > 0
			? new ActionResult<Movie>(true, HttpStatusCode.Accepted, null)
			: new ActionResult<Movie>(false, HttpStatusCode.NotFound, null);
	}

	public async Task<ActionResult<IEnumerable<MovieDto>>> GetAllAsync()
	{
		using var dbConnection = await connectionFactory.CreateConnectionAsync();
		var movies = await dbConnection.QueryAsync<Movie>("SELECT * FROM movies");

		var movieDtos = movies.Adapt<IEnumerable<MovieDto>>();

		return new ActionResult<IEnumerable<MovieDto>>(true, HttpStatusCode.OK, movieDtos);
	}

	public async Task<ActionResult<MovieDto>> GetByIdAsync(Guid id)
	{
		using var dbConnection = await connectionFactory.CreateConnectionAsync();
		var movieRow = await dbConnection.QuerySingleOrDefaultAsync(
			"""
			SELECT Id, Title FROM movies WHERE Id=@id
			""", new { id });

		if (movieRow is null)
		{
			return new ActionResult<MovieDto>(false, HttpStatusCode.NotFound, null);
		}

		var movieDto = new MovieDto(movieRow.Id, movieRow.Title);

		return new ActionResult<MovieDto>(true, HttpStatusCode.OK, movieDto);
	}

	public async Task<ActionResult<MovieDetailsDto>> GetDetailsAsync(Guid id)
	{
		using var dbConnection = await connectionFactory.CreateConnectionAsync();
		var movie = await dbConnection.QuerySingleOrDefaultAsync<Movie>(
			"""
			SELECT * FROM movies WHERE Id=@id
			""", new {id});

		if (movie is null)
		{
			return new ActionResult<MovieDetailsDto>(false, HttpStatusCode.NotFound, null);
		}

		var movieDetailsDto = movie.Adapt<MovieDetailsDto>();

		return new ActionResult<MovieDetailsDto>(true, HttpStatusCode.OK, movieDetailsDto);
	}

	public async Task<ActionResult<Movie>> UpdateAsync(Guid id, UpdateMovieDto updateMovieDto)
	{
		using var dbConntection = await connectionFactory.CreateConnectionAsync();
		var existingMovie = await dbConntection.QuerySingleOrDefaultAsync<Movie>(
			"""
			SELECT * FROM movies WHERE Id=@id
			""", new { id });

		if (existingMovie is null)
		{
			return new ActionResult<Movie>(false, HttpStatusCode.NotFound, null);
		}

		await dbConntection.ExecuteAsync(
			"""
			UPDATE movies SET Title=@Title, Director=@Director, ReleaseYear=@ReleaseYear WHERE Id=@Id
			""", new { Title = updateMovieDto.Title, Director = updateMovieDto.Director, ReleaseYear = updateMovieDto.ReleaseYear, Id = id});

		return new ActionResult<Movie>(true, HttpStatusCode.Accepted, null);
	}
}
