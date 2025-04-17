using DapperCrudPlayground.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DapperCrudPlayground.Core;
public static class DependencyInjection
{
	public static IServiceCollection AddCore(this IServiceCollection services)
	{
		services.AddScoped<IMovieService, MovieService>();

		return services;
	}
}
