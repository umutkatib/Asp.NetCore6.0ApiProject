namespace ApiProjectCamp.WebApi.Entities
{
	public class About
	{
		public int AboutID { get; set; }
		public string AboutTitle { get; set; }               
		public string AboutIntroText { get; set; }           // İtalik giriş cümlesi
		public string AboutItem1 { get; set; }               // Liste maddesi 1
		public string AboutItem2 { get; set; }               // Liste maddesi 2
		public string AboutItem3 { get; set; }               // Liste maddesi 3
		public string AboutDescription { get; set; }         // Liste altındaki paragraf
		public string AboutImageUrl { get; set; }            
		public string AboutVideoCoverImageUrl { get; set; }  
		public string AboutVideoUrl { get; set; }           // YouTube linki
		public string AboutReservationNumber { get; set; }   
	}
}
