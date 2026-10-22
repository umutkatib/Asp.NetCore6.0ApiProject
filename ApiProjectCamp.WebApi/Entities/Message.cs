namespace ApiProjectCamp.WebApi.Entities
{
	public class Message
	{
		public int MessageID { get; set; }
		public string MessageNameSurname { get; set; }
		public string MessageEmail { get; set; }
		public string MessageSubject { get; set; }
		public string MessageDetails { get; set; }
		public DateTime MessageSendDate { get; set; }
		public bool MessageStatus { get; set; }
	}
}
