using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.MessageDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public MessagesController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			return Ok(_mapper.Map<List<ResultMessageDto>>(_context.Messages.ToList()));
		}

		[HttpPost] 
		public IActionResult MessageCreate(CreateMessageDto createMessageDto)
		{
			var value = _mapper.Map<Message>(createMessageDto);
			_context.Messages.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete]
		public IActionResult MessageDelete(int id)
		{
			_context.Messages.Remove(_context.Messages.Find(id));
			_context.SaveChanges();
			return Ok();
		}


		[HttpPut]
		public IActionResult MessageUpdate(UpdateMessageDto updateMessageDto)
		{
			var value = _mapper.Map<Message>(updateMessageDto);
			_context.Messages.Update(value);
			_context.SaveChanges();
			return Ok();
		}


		[HttpGet("{id}")]
		public IActionResult MessageGet(int id)
		{
			var value = _context.Messages.Find(id);
			return Ok(_mapper.Map<Message>(value));
		}
	}
}
