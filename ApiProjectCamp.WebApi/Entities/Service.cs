namespace ApiProjectCamp.WebApi.Entities
{
	public class Service
	{
		public int ServiceID { get; set; }
		public string ServiceTitle { get; set; }
		public string ServiceDescription { get; set; }
		public string ServiceIconUrl { get; set; }
		public bool ServiceStatus { get; set; }
	}
}
