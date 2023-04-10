using System.ComponentModel.DataAnnotations.Schema;

namespace MyCookBook.Domain.Entities
{
	public class User : BaseEntity
	{
		
		[Column("name")]
		public string Name { get; set; }

		[Column("email")]
		public string Email { get; set; }

		[Column("password")]
		public string Password { get; set; }

		[Column("phone")]
		public string Phone { get; set; }
	}
}
