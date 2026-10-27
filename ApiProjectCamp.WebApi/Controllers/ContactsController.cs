using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Dtos.ContactDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly ApiContext _context;
		private readonly IMapper _mapper;

		public ContactsController(ApiContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			return Ok(_mapper.Map<List<ResultContactDto>>(_context.Contacts.ToList()));
		}

		// MANUEL MAPPING
		[HttpPost]
		public IActionResult ContactCrate(CreateContactDto createContactDto)
		{
			if (_context.Contacts.Any())
			{
				return BadRequest("Zaten bir kayıt mevcut, yeni kayıt eklenemez.");
			}
			_context.Contacts.Add(new Contact()
			{
				ContactMapLocation = createContactDto.ContactMapLocation,
				ContactAddress = createContactDto.ContactAddress,
				ContactEmail = createContactDto.ContactEmail,
				ContactOpenHours = createContactDto.ContactOpenHours,	
				ContactPhone = createContactDto.ContactPhone
			});
			_context.SaveChanges();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult ContactDelete(int id)
		{
			_context.Remove(_context.Contacts.Find(id));
			_context.SaveChanges();
			return Ok();
		}

		[HttpPut]
		public IActionResult ContactUpdate(UpdateContactDto updateContactDto)
		{
			_context.Contacts.Update(new Contact()
			{
				ContactMapLocation = updateContactDto.ContactMapLocation,
				ContactAddress = updateContactDto.ContactAddress,
				ContactEmail = updateContactDto.ContactEmail,
				ContactOpenHours = updateContactDto.ContactOpenHours,
				ContactPhone = updateContactDto.ContactPhone,
				ContactID = updateContactDto.ContactID,
			}); 
			_context.SaveChanges();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult ContactGet(int id)
		{
			return Ok(_context.Contacts.Find(id));
		}
	}
}
