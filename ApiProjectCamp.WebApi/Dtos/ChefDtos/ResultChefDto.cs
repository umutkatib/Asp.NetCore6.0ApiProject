namespace ApiProjectCamp.WebApi.Dtos.ChefDtos
{
	public class ResultChefDto
	{
		public int ChefID { get; set; }
		public string ChefNameSurname { get; set; }
		public string ChefTitle { get; set; }
		public string ChefDescription { get; set; }
		public string ChefImageUrl { get; set; }
		public bool ChefStatus { get; set; }
	}
}
