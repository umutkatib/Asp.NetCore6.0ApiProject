namespace ApiProjectCamp.WebUI.Dtos.ServiceDtos
{
	public class UpdateServiceDto
	{
		public int ServiceID { get; set; }
		public string ServiceTitle { get; set; }
		public string ServiceDescription { get; set; }
		public string ServiceIconUrl { get; set; }
		public bool ServiceStatus { get; set; }
	}
}
