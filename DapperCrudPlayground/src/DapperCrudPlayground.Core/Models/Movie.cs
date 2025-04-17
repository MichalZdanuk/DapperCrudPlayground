namespace DapperCrudPlayground.Core.Models;
public class Movie
{
	public Guid Id { get; set; }
	public string Title { get; set; } = default!;
	public int ReleaseYear { get; set; }
}
