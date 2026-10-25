namespace ApiProjectCamp.WebApi.Dtos.AboutDtos
{
	public class GetAboutDto
	{
		public int AboutID { get; set; }
		public string AboutTitle { get; set; }
		public string AboutIntroText { get; set; }          
		public string AboutItem1 { get; set; }              
		public string AboutItem2 { get; set; }              
		public string AboutItem3 { get; set; }              
		public string AboutDescription { get; set; }        
		public string AboutImageUrl { get; set; }
		public string AboutVideoCoverImageUrl { get; set; }
		public string AboutVideoUrl { get; set; }           
		public string AboutReservationNumber { get; set; }
	}
}
