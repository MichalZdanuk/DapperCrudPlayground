using DapperCrudPlayground.Core.DTO;
using DapperCrudPlayground.Core.Models;

namespace DapperCrudPlayground.Core.Services;
public interface IMovieService
{
	public Task<ActionResult<Movie>> AddAsync(CreateMovieDto createMovieDto);
	public Task<ActionResult<MovieDto>> GetByIdAsync(Guid id);
	public Task<ActionResult<IEnumerable<Movie>>> GetAllAsync();
	public Task<ActionResult<Movie>> UpdateAsync(Guid id, Movie movie);
	public Task<ActionResult<Movie>> DeleteAsync(Guid id);
}
