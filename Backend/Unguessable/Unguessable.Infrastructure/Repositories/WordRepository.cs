using Microsoft.EntityFrameworkCore;
using Unguessable.Domain.Entity;
using Unguessable.Domain.Repositories;
using Unguessable.Domain.Strategy;
using Unguessable.Infrastructure.Data;

namespace Unguessable.Infrastructure.Repositories
{
	public class WordRepository : IWordRepository
	{
		private readonly UnguessableData unguessableData;

		public WordRepository(UnguessableData unguessableData)
		{
			this.unguessableData = unguessableData;
		}
		public IEnumerable<GuessingWord> GetAll()
		{
			return unguessableData.Words;
		}

		public IEnumerable<GuessingWord> GetWordsByStrategy(IWordSearchStrategy wordSearchStrategy, int wordAmount = 35)
		{
			return wordSearchStrategy.Words(unguessableData.Words).OrderBy(o => EF.Functions.Random())
			.Take(wordAmount);
		}
	}
}
