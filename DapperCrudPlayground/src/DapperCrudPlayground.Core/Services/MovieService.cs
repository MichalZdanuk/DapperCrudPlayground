using DapperCrudPlayground.Core.Models;

namespace DapperCrudPlayground.Core.Services;
public class MovieService
	: IMovieService
{
	public Task<ActionResult<Movie>> AddAsync(Movie movie)
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<Movie>> DeleteAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<IEnumerable<Movie>>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<Movie>> GetByIdAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<ActionResult<Movie>> UpdateAsync(Guid id, Movie movie)
	{
		throw new NotImplementedException();
	}
}
