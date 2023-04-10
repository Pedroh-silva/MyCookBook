using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MyCookBook.Infrastructure.Migrations
{
	public static class Database
	{
		public static void CreateDataBase(string connectionWithDataBase, string dataBaseName)
		{
			using var myConnection = new SqlConnection(connectionWithDataBase);
			var parameters = new DynamicParameters();
			parameters.Add("name", dataBaseName);
			var queryResult = myConnection.Query("SELECT name FROM sys.databases WHERE name = @name", parameters);

			if (!queryResult.Any())
			{
				myConnection.Execute($"CREATE DATABASE {dataBaseName}");
			}

		}
	}
}
