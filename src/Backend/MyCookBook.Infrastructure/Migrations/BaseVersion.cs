using FluentMigrator.Builders.Create.Table;

namespace MyCookBook.Infrastructure.Migrations
{
	public static class BaseVersion
	{
		public static ICreateTableColumnOptionOrWithColumnSyntax InsertDeafultColumns(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
		{
			return table
				.WithColumn("id").AsInt32().PrimaryKey().Identity()
				.WithColumn("created_date").AsDateTime().NotNullable();
		}
	}
}
