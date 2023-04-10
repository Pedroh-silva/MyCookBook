using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCookBook.Domain.Extension;

namespace MyCookBook.Infrastructure
{
	public static class Bootstrapper
	{
		public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
		{
			AddFluentMigrator(services, configuration);
		}
		private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration) 
		{
			services.AddFluentMigratorCore().ConfigureRunner(c =>
			c.AddSqlServer()
			.WithGlobalConnectionString(configuration.GenerateConnectionString()).ScanIn(Assembly.Load("MyCookBook.Infrastructure")).For.All());
		}
	}
}
