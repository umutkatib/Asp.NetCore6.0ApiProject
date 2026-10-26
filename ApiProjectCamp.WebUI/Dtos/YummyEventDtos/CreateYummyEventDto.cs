namespace ApiProjectCamp.WebUI.Dtos.YummyEventDtos
{
	public class CreateYummyEventDto
	{
		public string YummyEventTitle { get; set; }
		public string YummyEventDescription { get; set; }
		public string YummyEventImageUrl { get; set; }
		public bool YummyEventStatus { get; set; }
		public decimal YummyEventPrice { get; set; }
	}
}
