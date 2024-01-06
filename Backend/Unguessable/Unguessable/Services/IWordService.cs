using Unguessable.DTO;

namespace Unguessable.Services
{
	public interface IWordService
	{
		Task<IEnumerable<GetWordDTOResponse>> GetAllWords();
		Task<IEnumerable<GetWordDTOResponse>> GetWordsByCategories(int[] categorieIDS);
	}
}