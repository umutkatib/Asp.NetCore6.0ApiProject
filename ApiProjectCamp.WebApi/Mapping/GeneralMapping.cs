using ApiProjectCamp.WebApi.Dtos.CategoryDtos;
using ApiProjectCamp.WebApi.Dtos.ChefDtos;
using ApiProjectCamp.WebApi.Dtos.ContactDtos;
using ApiProjectCamp.WebApi.Dtos.FeatureDtos;
using ApiProjectCamp.WebApi.Dtos.ImageDtos;
using ApiProjectCamp.WebApi.Dtos.MessageDtos;
using ApiProjectCamp.WebApi.Dtos.ProductDtos;
using ApiProjectCamp.WebApi.Dtos.ReservationDtos;
using ApiProjectCamp.WebApi.Dtos.ServiceDtos;
using ApiProjectCamp.WebApi.Dtos.TestimonialDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;

namespace ApiProjectCamp.WebApi.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{
			//	CATEGORY MAPPING
			CreateMap<Category, ResultCategoryDto>().ReverseMap();
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();
			CreateMap<Category, GetCategoryDto>().ReverseMap();

			//	CHEF MAPPING
			CreateMap<Chef, ResultChefDto>().ReverseMap();
			CreateMap<Chef, CreateChefDto>().ReverseMap();
			CreateMap<Chef, UpdateChefDto>().ReverseMap();
			CreateMap<Chef, GetChefDto>().ReverseMap();

			//	CONTACT MAPPING
			CreateMap<Contact, ResultContactDto>().ReverseMap();
			CreateMap<Contact, CreateContactDto>().ReverseMap();
			CreateMap<Contact, UpdateContactDto>().ReverseMap();
			CreateMap<Contact, GetContactDto>().ReverseMap();

			//	FEATURE MAPPING
			CreateMap<Feature, ResultFeatureDto>().ReverseMap();
			CreateMap<Feature, CreateFeatureDto>().ReverseMap();
			CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
			CreateMap<Feature, GetFeatureDto>().ReverseMap();

			//	IMAGE MAPPING
			CreateMap<Image, ResultImageDto>().ReverseMap();
			CreateMap<Image, CreateImageDto>().ReverseMap();
			CreateMap<Image, UpdateImageDto>().ReverseMap();
			CreateMap<Image, GetImageDto>().ReverseMap();

			//	MESSAGE MAPPING
			CreateMap<Message, ResultMessageDto>().ReverseMap();
			CreateMap<Message, CreateMessageDto>().ReverseMap();
			CreateMap<Message, UpdateMessageDto>().ReverseMap();
			CreateMap<Message, GetMessageDto>().ReverseMap();

			// PRODUCT MAPPING
			CreateMap<Product, ResultProductDto>().ReverseMap();
			CreateMap<Product, CreateProductDto>().ReverseMap();
			CreateMap<Product, UpdateProductDto>().ReverseMap();
			CreateMap<Product, GetProductDto>().ReverseMap();
			CreateMap<Product, ResultProductWithCategoryNameDto>()
				.ForMember(x => x.CategoryName, 
						   y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();

			// RESERVATION MAPPING
			CreateMap<Reservation, ResultReservationDto>().ReverseMap();
			CreateMap<Reservation, CreateReservationDto>().ReverseMap();
			CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
			CreateMap<Reservation, GetReservationDto>().ReverseMap();

			// SERVICE MAPPING
			CreateMap<Service, ResultServiceDto>().ReverseMap();
			CreateMap<Service, CreateServiceDto>().ReverseMap();
			CreateMap<Service, UpdateServiceDto>().ReverseMap();
			CreateMap<Service, GetServiceDto>().ReverseMap();

			// TESTIMONIAL MAPPING
			CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
		}
	}
}
