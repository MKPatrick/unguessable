using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unguessable.Domain.Entity;
using Unguessable.Domain.Strategy;

namespace Unguessable.Domain.Repositories
{
	public interface IWordRepository
	{
		public IEnumerable<GuessingWord> GetAll();	
		public IEnumerable<GuessingWord> GetWordsByStrategy(IWordSearchStrategy wordSearchStrategy, int wordAmount=35);
	}
}
