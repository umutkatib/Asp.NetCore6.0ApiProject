using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ApiContext _context;

		public CategoriesController(ApiContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return Ok(_context.Categories.ToList());
		}

		[HttpPost]
		public IActionResult CategoryCreate(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete]
		public IActionResult CategoryDelete(int id)
		{
			_context.Categories.Remove(_context.Categories.Find(id));
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult CategoryUpdate(Category category)
		{
			_context.Categories.Update(category);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult CategoryGet(int id)
		{
			return Ok(_context.Categories.Find(id));
		}
	}
}
