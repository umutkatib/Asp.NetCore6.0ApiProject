namespace ApiProjectCamp.WebApi.Dtos.TestimonialDtos
{
	public class UpdateTestimonialDto
	{
		public int TestimonialID { get; set; }
		public string TestimonialNameSurname { get; set; }
		public string TestimonialTitle { get; set; }
		public string TestimonialComment { get; set; }
		public string TestimonialImageURl { get; set; }
		public bool TestimonialStatus { get; set; }
	}
}
