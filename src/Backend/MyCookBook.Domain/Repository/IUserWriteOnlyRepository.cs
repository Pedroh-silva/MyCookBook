using MyCookBook.Domain.Entities;

namespace MyCookBook.Domain.Repository
{
	public interface IUserWriteOnlyRepository
	{
		Task Add(User user);
	}
}
