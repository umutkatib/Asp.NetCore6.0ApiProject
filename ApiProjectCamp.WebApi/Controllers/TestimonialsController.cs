using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.TestimonialDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialsController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;
		//private readonly IValidator<>;

		public TestimonialsController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult TestimonialList()
		{
			return Ok(_mapper.Map<List<ResultTestimonialDto>>(_context.Testimonials.ToList()));
		}

		[HttpPost]
		public IActionResult TestimonialCreate(CreateTestimonialDto createTestimonialDto)
		{
			var value = _mapper.Map<Testimonial>(createTestimonialDto);
			_context.Testimonials.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult TestimonialDelete(int id)
		{
			var value = _context.Testimonials.Find(id);
			_context.Testimonials.Remove(value);
			_context.SaveChanges();
			return Ok();	
		}

		[HttpPut]
		public IActionResult TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
		{
			var value = _mapper.Map<Testimonial>(updateTestimonialDto);
			_context.Testimonials.Update(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult TestimonialGet(int id)
		{
			return Ok(_mapper.Map<GetTestimonialDto>(_context.Testimonials.Find(id)));
		}
	}
}
