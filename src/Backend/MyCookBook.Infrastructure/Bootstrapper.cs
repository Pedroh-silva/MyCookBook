using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCookBook.Domain.Extension;
using MyCookBook.Domain.Repository;
using MyCookBook.Infrastructure.Context;
using MyCookBook.Infrastructure.Data;
using MyCookBook.Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace MyCookBook.Infrastructure
{
	public static class Bootstrapper
	{
		public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
		{
			AddFluentMigrator(services, configuration);


			AddContext(services, configuration);
			AddUnitOfWork(services);
			AddRepositories(services);
		}

		private static void AddContext(IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GenerateConnectionString();

			services.AddDbContext<MyCookBookContext>(dbContextOptions =>
			dbContextOptions.UseSqlServer(connectionString));
		}
		
		private static void AddUnitOfWork(IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}

		private static void AddRepositories(IServiceCollection services)
		{
			services.AddScoped<IUserReadOnlyRepository, UserRepository>()
				.AddScoped<IUserReadOnlyRepository, UserRepository>();
		}

		private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration) 
		{
			services.AddFluentMigratorCore().ConfigureRunner(c =>
			c.AddSqlServer()
			.WithGlobalConnectionString(configuration.GenerateConnectionString()).ScanIn(Assembly.Load("MyCookBook.Infrastructure")).For.All());
		}
	}
}
