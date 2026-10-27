using ApiProjectCamp.WebUI.Dtos.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjectCamp.WebUI.Controllers
{
	public class ReservationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ReservationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> ReservationList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/Reservations");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult ReservationCreate()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ReservationCreate(CreateReservationDto createReservationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createReservationDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7246/api/Reservations", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ReservationList");
			}
			return View();
		}


		public async Task<IActionResult> ReservationDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7246/api/Reservations/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ReservationList");
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> ReservationUpdate(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7246/api/Reservations/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateReservationDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ReservationUpdate(UpdateReservationDto updateReservationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateReservationDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7246/api/Reservations", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ReservationList");
			}
			return View();
		}

		public async Task<IActionResult> ReservationChangeStatus(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7246/api/Reservations/ReservationChangeStatus/{id}");
			return RedirectToAction("ReservationList");
		}
	}
}
