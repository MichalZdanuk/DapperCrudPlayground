using DapperCrudPlayground.Core.DTO;
using DapperCrudPlayground.Core.Models;

namespace DapperCrudPlayground.Core.Services;
public interface IMovieService
{
	public Task<ActionResult<Movie>> AddAsync(CreateMovieDto createMovieDto);
	public Task<ActionResult<MovieDto>> GetByIdAsync(Guid id);
	public Task<ActionResult<MovieDetailsDto>> GetDetailsAsync(Guid id);
	public Task<ActionResult<IEnumerable<MovieDto>>> GetAllAsync();
	public Task<ActionResult<Movie>> UpdateAsync(Guid id, UpdateMovieDto movie);
	public Task<ActionResult<Movie>> DeleteAsync(Guid id);
}
