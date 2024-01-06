using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unguessable.Domain.Entity;

namespace Unguessable.Domain.Strategy
{
	public class WordSearchStrategyCategories : IWordSearchStrategy
	{
		private readonly IEnumerable<int> categories;

		public WordSearchStrategyCategories(IEnumerable<int> categories)
		{
			this.categories = categories;
		}


		public IQueryable<GuessingWord> Words(IQueryable<GuessingWord> words)
		{
			return words.Where(x => categories.Contains(x.CategoryID));
		}
	}
}
