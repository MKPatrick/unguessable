using Mapster;
using Unguessable.Domain.Repositories;
using Unguessable.DTO;

namespace Unguessable.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}
		public async Task<IEnumerable<GetCategoriesDTOResponse>> GetCategories()
		{
			return categoryRepository.GetAllCategories().Adapt<List<GetCategoriesDTOResponse>>();
		}
	}
}
