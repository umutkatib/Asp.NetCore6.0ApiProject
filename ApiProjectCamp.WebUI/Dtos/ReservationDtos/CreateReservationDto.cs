namespace ApiProjectCamp.WebUI.Dtos.ReservationDtos
{
	public class CreateReservationDto
	{
		public string ReservationNameSurname { get; set; }
		public string ReservationPhone { get; set; }
		public string ReservationEmail { get; set; }
		public DateTime ReservationDate { get; set; }
		public string ReservationTime { get; set; }
		public int ReservationCountOfPeople { get; set; }
		public string ReservationMessage { get; set; }
		public bool ReservationStatus { get; set; }
	}
}
