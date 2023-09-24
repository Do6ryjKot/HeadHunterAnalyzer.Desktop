namespace Entities.Models {
	
	public class AnalyzedVacancy {

		public string Name { get; set; }
		public string Experience { get; set; }
		public string Body { get; set; }
		public AnalyzedCompany Company { get; set; }
		public bool AlreadyAnalyzed { get; set; }
		public IEnumerable<Word> Words { get; set; }
	}
}
