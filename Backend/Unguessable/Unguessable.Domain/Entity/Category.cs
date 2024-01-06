namespace Unguessable.Domain.Entity
{
	public class Category
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string ImageUrl { get; set; }
		public IEnumerable<GuessingWord> Words { get; set; }
	}
}
