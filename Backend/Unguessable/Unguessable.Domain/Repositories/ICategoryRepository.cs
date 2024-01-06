using Unguessable.Domain.Entity;

namespace Unguessable.Domain.Repositories
{
	public interface ICategoryRepository
	{
		public IEnumerable<Category> GetAllCategories();
	}
}
