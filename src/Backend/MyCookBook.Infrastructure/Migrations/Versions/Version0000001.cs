using FluentMigrator;

namespace MyCookBook.Infrastructure.Migrations.Versions
{
	[Migration((long)VersionNumbers.CreateUserTable,"Create user table")]
	public class Version0000001 : Migration
	{
		public override void Down()
		{
		}

		public override void Up()
		{
			var table = BaseVersion.InsertDeafultColumns(Create.Table("User"));

			table
				.WithColumn("name").AsString(100).NotNullable()
				.WithColumn("email").AsString(255).NotNullable()
				.WithColumn("password").AsString(128).NotNullable()
				.WithColumn("phone").AsString(14).NotNullable();
		}
	}
}
