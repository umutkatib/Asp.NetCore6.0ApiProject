namespace ApiProjectCamp.WebUI.Dtos.WhyChooseYummyDtos
{
	public class UpdateWhyChooseYummyDto
	{
		public int ServiceID { get; set; }
		public string ServiceTitle { get; set; }
		public string ServiceDescription { get; set; }
		public string ServiceIconUrl { get; set; }
		public bool ServiceStatus { get; set; }
	}
}
