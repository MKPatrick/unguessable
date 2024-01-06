using Unguessable.DTO;

namespace Unguessable.Services
{
	public interface ICategoryService
	{
		Task<IEnumerable<GetCategoriesDTOResponse>> GetCategories();
	}
}