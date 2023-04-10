namespace MyCookBook.Domain.Repository
{
	public interface IUnitOfWork
	{
		Task Commit();
	}
}
