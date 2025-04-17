using DapperCrudPlayground.Core.Database;
using DapperCrudPlayground.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DapperCrudPlayground.Core;
public static class DependencyInjection
{
	public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSingleton<IDbConnectionFactory>(_ => new DbConnectionFactory(configuration["DbConnectionString"]!));

		services.AddSingleton<IMovieService, MovieService>();

		return services;
	}
}
