using DapperCrudPlayground.Core.Models;

namespace DapperCrudPlayground.Core.Services;
public class MovieService
	: IMovieService
{
	public Task<bool> AddAsync(Movie movie)
	{
		throw new NotImplementedException();
	}

	public Task<bool> DeleteAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Movie>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<Movie?> GetByIdAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<bool> UpdateAsync(Guid id, Movie movie)
	{
		throw new NotImplementedException();
	}
}
