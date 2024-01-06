using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unguessable.Domain.Entity
{
	public class GuessingWord
	{
		public int ID { get; set; }
		public string Word { get; set; }
		public Category Category { get; set; }
		public int CategoryID { get; set; }
		public string WordForbidden1 { get; set; }
		public string WordForbidden2 { get; set; }
		public string WordForbidden3 { get; set; }
	}
}
