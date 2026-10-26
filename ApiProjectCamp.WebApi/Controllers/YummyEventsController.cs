using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.YummyEvent;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class YummyEventsController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public YummyEventsController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		[HttpGet]
		public IActionResult YummyEventList()
		{
			return Ok(_mapper.Map<List<ResultYummyEventDto>>(_context.YummyEvents.ToList()));
		}


		[HttpPost]
		public IActionResult YummyEventCreate(CreateYummyEventDto createYummyEventDto)
		{
			createYummyEventDto.YummyEventStatus = true;
			var value = _mapper.Map<YummyEvent>(createYummyEventDto);
			_context.YummyEvents.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult YummyEventDelete(int id)
		{
			var value = _context.YummyEvents.Find(id);
			_context.YummyEvents.Remove(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult YummyEventUpdate(UpdateYummyEventDto updateYummyEventDto)
		{
			updateYummyEventDto.YummyEventStatus = true;
			var value = _mapper.Map<YummyEvent>(updateYummyEventDto);
			_context.YummyEvents.Update(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult YummyEventGet(int id)
		{
			return Ok(_mapper.Map<GetYummyEventDto>(_context.YummyEvents.Find(id)));
		}

		[HttpGet("YummyEventActiveList")]
		public IActionResult YummyEventActiveList()
		{
			return Ok(_mapper.Map<List<ResultYummyEventDto>>(_context.YummyEvents.Where(x => x.YummyEventStatus).ToList()));
		}

		[HttpGet("YummyEventChangeStatus/{id}")]
		public IActionResult YummyEventChangeStatus(int id)
		{
			var value = _context.YummyEvents.Find(id);
			value.YummyEventStatus = !value.YummyEventStatus;
			_context.SaveChanges();
			return Ok();
		}
	}
}
