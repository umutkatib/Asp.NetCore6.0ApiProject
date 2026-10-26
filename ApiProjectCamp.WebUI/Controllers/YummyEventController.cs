using ApiProjectCamp.WebUI.Dtos.YummyEventDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiProjectCamp.WebUI.Controllers
{
	public class YummyEventController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public YummyEventController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> YummyEventList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/YummyEvents");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultYummyEventDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult YummyEventCreate()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> YummyEventCreate(CreateYummyEventDto createYummyEventDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createYummyEventDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7246/api/YummyEvents", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("YummyEventList");
			}
			return View();
		}


		public async Task<IActionResult> YummyEventDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7246/api/YummyEvents/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("YummyEventList");
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> YummyEventUpdate(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7246/api/YummyEvents/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateYummyEventDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> YummyEventUpdate(UpdateYummyEventDto updateYummyEventDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateYummyEventDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7246/api/YummyEvents", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("YummyEventList");
			}
			return View();
		}

		public async Task<IActionResult> YummyEventChangeStatus(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7246/api/YummyEvents/YummyEventChangeStatus/{id}");
			return RedirectToAction("YummyEventList");
		}
	}
}
