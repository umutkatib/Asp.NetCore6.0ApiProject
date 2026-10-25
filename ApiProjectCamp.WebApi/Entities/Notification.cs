namespace ApiProjectCamp.WebApi.Entities
{
	public class Notification
	{
		public int NotificationID { get; set; }
		public string NotificationDescription { get; set; }
		public string NotificationIconURl { get; set; }
		public DateTime NotificationDate { get; set; }
		public bool NotificationStatus { get; set; }
	}
}
