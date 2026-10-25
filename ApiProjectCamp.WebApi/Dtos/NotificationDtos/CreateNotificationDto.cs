namespace ApiProjectCamp.WebApi.Dtos.NotificationDtos
{
	public class CreateNotificationDto
	{
		public string NotificationDescription { get; set; }
		public string NotificationIconURl { get; set; }
		public DateTime NotificationDate { get; set; }
		public bool NotificationStatus { get; set; }
	}
}
