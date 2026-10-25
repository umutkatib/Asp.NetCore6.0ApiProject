using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChefsController : ControllerBase
	{
		private readonly ApiContext _context;

		public ChefsController(ApiContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult ChefList()
		{
			return Ok(_context.Chefs.ToList());
		}

		[HttpPost]
		public IActionResult ChefCreate(Chef chef)
		{
			_context.Chefs.Add(chef);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult ChefDelete(int id)
		{
			_context.Chefs.Remove(_context.Chefs.Find(id));
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult ChefUpdate(Chef chef)
		{
			_context.Chefs.Update(chef);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult ChefGet(int id)
		{
			return Ok(_context.Chefs.Find(id));
		}
	}
}
