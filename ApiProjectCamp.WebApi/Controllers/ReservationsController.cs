using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ReservationDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationsController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public ReservationsController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ReservationList()
		{
			return Ok(_mapper.Map<List<ResultReservationDto>>(_context.Reservations.ToList()));
		}

		[HttpPost]
		public IActionResult ReservationCreate(CreateReservationDto createReservationDto)
		{
			var value = _mapper.Map<Reservation>(createReservationDto);
			_context.Reservations.Add(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult ReservationDelete(int id)
		{
			_context.Reservations.Remove(_context.Reservations.Find(id));
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult ReservationUpdate(UpdateReservationDto updateReservationDto)
		{
			var value = _mapper.Map<Reservation>(updateReservationDto);
			_context.Reservations.Update(value);
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult ReservationGet(int id)
		{
			var value = _context.Reservations.Find(id);
			return Ok(_mapper.Map<GetReservationDto>(value));
		}

		[HttpGet("ReservationChangeStatus/{id}")]
		public IActionResult ReservationChangeStatus(int id)
		{
			var value = _context.Reservations.Find(id);
			value.ReservationStatus = !value.ReservationStatus;
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("ReservationGetTotalCount")]
		public IActionResult ReservationGetTotalCount()
		{
			var value = _context.Reservations.Count();
			return Ok(value);
		}

		[HttpGet("CustomerGetTotalCount")]
		public IActionResult CustomerGetTotalCount()
		{
			var value = _context.Reservations.Sum(x => x.ReservationCountOfPeople);
			return Ok(value);
		}

		[HttpGet("ReservationGetPendingCount")]
		public IActionResult ReservationGetPendingCount()
		{
			var value = _context.Reservations.Where(x => x.ReservationStatus == false).Count();
			return Ok(value);
		}

		[HttpGet("ReservationGetApprovedCount")]
		public IActionResult ReservationGetApprovedCount()
		{
			var value = _context.Reservations.Where(x => x.ReservationStatus == true).Count();
			return Ok(value);
		}
	}
}
