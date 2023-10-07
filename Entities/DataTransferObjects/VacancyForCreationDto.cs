namespace Entities.DataTransferObjects {
	
	public class VacancyForCreationDto {

		public int HeadHunterId { get; set; }
		
		public IEnumerable<WordForCreationDto> Words { get; set; }
	}
}
