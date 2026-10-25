using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.NotificationDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public NotificationsController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_mapper.Map<List<ResultNotificationDto>>(_context.Notifications.ToList()));
		}

		[HttpPost]
		public IActionResult NotificationCreate(CreateNotificationDto createNotificationDto)
		{
			var value = _mapper.Map<Notification>(createNotificationDto);
			_context.Notifications.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete]
		public IActionResult NotificationDelete(int id)
		{
			var value = _context.Notifications.Find(id);
			_context.Notifications.Remove(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult NotificationUpdate(UpdateNotificationDto updateNotificationDto)
		{
			var value = _mapper.Map<Notification>(updateNotificationDto);
			_context.Notifications.Update(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult NotificationGet(int id)
		{
			return Ok(_mapper.Map<GetNotificationDto>(_context.Notifications.Find(id)));
		}
	}
}
