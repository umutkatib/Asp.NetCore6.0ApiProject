using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.FeatureDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public FeaturesController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult FeatureList()
		{
			return Ok(_mapper.Map<List<ResultFeatureDto>>(_context.Features.ToList()));
		}

		[HttpPost]
		public IActionResult FeatureCreate(CreateFeatureDto createFeatureDto)
		{
			if(_context.Features.Any())
			{
				return BadRequest("Zaten bir kayıt mevcut, yeni kayıt eklenemez.");
			}
			var value = _mapper.Map<Feature>(createFeatureDto);
			_context.Features.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult FeatureDelete(int id)
		{
			_context.Features.Remove(_context.Features.Find(id));
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult FeatureUpdate(UpdateFeatureDto updateFeatureDto)
		{
			var value = _mapper.Map<Feature>(updateFeatureDto);
			_context.Features.Update(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult FeatureGet(int id)
		{
			var value = _context.Features.Find(id);
			return Ok(_mapper.Map<GetFeatureDto>(value));
		}
	}
}
