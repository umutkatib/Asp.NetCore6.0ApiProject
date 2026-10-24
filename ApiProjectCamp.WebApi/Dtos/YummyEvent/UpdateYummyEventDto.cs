namespace ApiProjectCamp.WebApi.Dtos.YummyEvent
{
	public class UpdateYummyEventDto
	{
		public int YummyEventID { get; set; }
		public string YummyEventTitle { get; set; }
		public string YummyEventDescription { get; set; }
		public string YummyEventImageUrl { get; set; }
		public bool YummyEventStatus { get; set; }
		public decimal YummyEventPrice { get; set; }
	}
}
