namespace MyCookBook.Domain.Repository
{
	public interface IUserReadOnlyRepository
	{
		Task<bool> IsUserEmailExists(string email);
	}
}
