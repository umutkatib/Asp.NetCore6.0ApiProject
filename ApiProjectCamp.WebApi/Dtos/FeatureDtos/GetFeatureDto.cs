namespace ApiProjectCamp.WebApi.Dtos.FeatureDtos
{
	public class GetFeatureDto
	{
		public int FeatureID { get; set; }
		public string FeatureTitle { get; set; }
		public string FeatureSubTitle { get; set; }
		public string FeatureDescription { get; set; }
		public string FeatureVideoUrl { get; set; }
		public string FeatureImageUrl { get; set; }
		//public bool FeatureStatus { get; set; }
	}
}
