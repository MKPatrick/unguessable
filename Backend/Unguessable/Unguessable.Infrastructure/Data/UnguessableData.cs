using Microsoft.EntityFrameworkCore;
using Unguessable.Domain.Entity;

namespace Unguessable.Infrastructure.Data
{
	public class UnguessableData : DbContext
	{
		public DbSet<Category> Categories { get; set; }	
		public DbSet<GuessingWord> Words { get;set; }
		public UnguessableData(DbContextOptions options) : base(options)
		{
		}

	}
}
