using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.CategoryDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public CategoriesController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult Index()
		{
			//return Ok(_context.Categories.ToList());
			return Ok(_mapper.Map<List<ResultCategoryDto>>(_context.Categories.ToList()));
		}

		[HttpPost]
		public IActionResult CategoryCreate(CreateCategoryDto createCategoryDto)
		{
			//_context.Categories.Add(category);
			//_context.SaveChanges();

			createCategoryDto.CategoryStatus = true;
			var value = _mapper.Map<Category>(createCategoryDto);
			_context.Categories.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult CategoryDelete(int id)
		{
			_context.Categories.Remove(_context.Categories.Find(id));
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult CategoryUpdate(UpdateCategoryDto updateCategoryDto)
		{
			//_context.Categories.Update(category);
			//_context.SaveChanges();

			updateCategoryDto.CategoryStatus = true;
			var value = _mapper.Map<Category>(updateCategoryDto);
			_context.Categories.Update(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult CategoryGet(int id)
		{
			return Ok(_mapper.Map<ResultCategoryDto>(_context.Categories.Find(id)));
		}

		[HttpGet("CategoryChangeStatus/{id}")]
		public IActionResult CategoryChangeStatus(int id)
		{
			var value = _context.Categories.Find(id);
			value.CategoryStatus = !value.CategoryStatus;
			_context.SaveChanges();
			return Ok();
		}
	}
}
