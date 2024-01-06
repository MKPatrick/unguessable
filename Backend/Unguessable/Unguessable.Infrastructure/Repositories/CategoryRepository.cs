using Unguessable.Domain.Entity;
using Unguessable.Domain.Repositories;
using Unguessable.Infrastructure.Data;

namespace Unguessable.Infrastructure.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly UnguessableData unguessableData;

		public CategoryRepository(UnguessableData unguessableData)
		{
			this.unguessableData = unguessableData;
		}
		public IEnumerable<Category> GetAllCategories()
		{
			return unguessableData.Categories;
		}
	}
}
