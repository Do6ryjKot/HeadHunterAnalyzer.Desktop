namespace Entities.Models {
	
	public class Vacancy {

		public Guid Id { get; set; }

		public int HeadHunterId { get; set; }

		public string Name { get; set; }

		public List<Word> Words { get; set; } = new List<Word>();
	}
}
