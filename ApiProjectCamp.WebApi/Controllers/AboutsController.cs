using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.AboutDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public AboutsController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			return Ok(_mapper.Map<List<ResultAboutDto>>(_context.Abouts.ToList()));
		}

		[HttpPost]
		public IActionResult AboutCreate(CreateAboutDto createAboutDto)
		{
			if (_context.Features.Any())
			{
				return BadRequest("Zaten bir kayıt mevcut, yeni kayıt eklenemez.");
			}
			var value = _mapper.Map<About>(createAboutDto);
			_context.Abouts.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult AboutDelete(int id)
		{
			_context.Abouts.Remove(_context.Abouts.Find(id));
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult AboutUpdate(UpdateAboutDto updateAboutDto)
		{
			var value = _mapper.Map<About>(updateAboutDto);
			_context.Abouts.Update(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult AboutGet(int id)
		{
			var value = _context.Abouts.Find(id);
			return Ok(_mapper.Map<GetAboutDto>(value));
		}
	}
}
