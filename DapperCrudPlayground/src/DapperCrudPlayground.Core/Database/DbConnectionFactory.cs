using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperCrudPlayground.Core.Database;
public class DbConnectionFactory(string connectionString)
	: IDbConnectionFactory
{
	public async Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default)
	{
		var connection = new SqlConnection(connectionString);
		await connection.OpenAsync(token);
		return connection;
	}
}

public interface IDbConnectionFactory
{
	Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default);
}
