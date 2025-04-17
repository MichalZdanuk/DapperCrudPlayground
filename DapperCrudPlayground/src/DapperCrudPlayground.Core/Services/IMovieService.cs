using DapperCrudPlayground.Core.Models;

namespace DapperCrudPlayground.Core.Services;
public interface IMovieService
{
	public Task<bool> AddAsync(Movie movie);
	public Task<Movie?> GetByIdAsync(Guid id);
	public Task<IEnumerable<Movie>> GetAllAsync();
	public Task<bool> UpdateAsync(Guid id, Movie movie);
	public Task<bool> DeleteAsync(Guid id);
}
