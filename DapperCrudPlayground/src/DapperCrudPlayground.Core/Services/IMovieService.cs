using DapperCrudPlayground.Core.Models;

namespace DapperCrudPlayground.Core.Services;
public interface IMovieService
{
	public Task<ActionResult<Movie>> AddAsync(Movie movie);
	public Task<ActionResult<Movie>> GetByIdAsync(Guid id);
	public Task<ActionResult<IEnumerable<Movie>>> GetAllAsync();
	public Task<ActionResult<Movie>> UpdateAsync(Guid id, Movie movie);
	public Task<ActionResult<Movie>> DeleteAsync(Guid id);
}
