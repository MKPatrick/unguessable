using Mapster;
using Unguessable.Domain.Repositories;
using Unguessable.Domain.Strategy;
using Unguessable.DTO;

namespace Unguessable.Services
{
	public class WordService : IWordService
	{
		private readonly IWordRepository wordRepository;

		public WordService(IWordRepository wordRepository)
		{
			this.wordRepository = wordRepository;
		}

		public async Task<IEnumerable<GetWordDTOResponse>> GetAllWords()
		{
			return wordRepository.GetAll().Adapt<List<GetWordDTOResponse>>();
		}

		public async Task<IEnumerable<GetWordDTOResponse>> GetWordsByCategories(int[] categorieIDS)
		{
			IWordSearchStrategy wordSearchStrategy = new WordSearchStrategyCategories(categorieIDS);
			return wordRepository.GetWordsByStrategy(wordSearchStrategy).Adapt<List<GetWordDTOResponse>>();
		}

	}
}
