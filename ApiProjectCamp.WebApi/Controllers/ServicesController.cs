using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ServiceDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;
		//private readonly IValidator<> _validator;

		public ServicesController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		[HttpGet]
		public IActionResult ServiceList()
		{
			return Ok(_mapper.Map<List<Service>>(_context.Services.ToList()));
		}

		[HttpPost]
		public IActionResult ServiceCreate(CreateServiceDto createServiceDto)
		{
			var value = _mapper.Map<Service>(createServiceDto);
			_context.Services.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult ServiceDelete(int id)
		{
			_context.Services.Remove(_context.Services.Find(id));
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult ServiceUpdte(UpdateServiceDto updateServiceDto)
		{
			var value = _mapper.Map<Service>(updateServiceDto);
			_context.Services.Update(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult ServiceGet(int id)
		{
			var value = _context.Services.Find(id);
			return Ok(_mapper.Map<GetServiceDto>(value));
		}
	}
}
