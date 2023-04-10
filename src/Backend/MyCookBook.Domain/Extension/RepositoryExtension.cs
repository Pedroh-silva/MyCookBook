using Microsoft.Extensions.Configuration;

namespace MyCookBook.Domain.Extension;

public static class RepositoryExtension
{
	public static string GetDatabaseName(this IConfiguration configuration)
	{
		var dataBaseName = configuration.GetConnectionString("DatabaseName");
		return dataBaseName;
	}
	public static string GetDatabaseConnection(this IConfiguration configuration)
	{
		var connection = configuration.GetConnectionString("connection");
		return connection;
	}
}
