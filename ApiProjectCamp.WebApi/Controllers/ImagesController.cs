using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ImageDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public ImagesController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return Ok(_mapper.Map<List<ResultImageDto>>(_context.Images.ToList()));
		}

		[HttpPost]
		public IActionResult ImageCreate(CreateImageDto createImageDto)
		{
			var value = _mapper.Map<Image>(createImageDto);
			_context.Images.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult ImageDelete(int id)
		{
			_context.Images.Remove(_context.Images.Find(id));
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult ImageUpdate(UpdateImageDto updateImageDto)
		{
			var value = _mapper.Map<Image>(updateImageDto);
			_context.Images.Update(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult ImageGet(int id)
		{
			return Ok(_mapper.Map<ResultImageDto>(_context.Images.Find(id)));
		}
	}
}
