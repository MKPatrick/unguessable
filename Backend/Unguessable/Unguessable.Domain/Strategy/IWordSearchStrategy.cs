using Unguessable.Domain.Entity;

namespace Unguessable.Domain.Strategy
{
	public interface IWordSearchStrategy
	{
		IQueryable<GuessingWord> Words(IQueryable<GuessingWord> words);
	}
}
