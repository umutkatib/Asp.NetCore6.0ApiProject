using ApiProjectCamp.WebUI.Dtos.WhyChooseYummyDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApiProjectCamp.WebUI.Controllers
{
	public class WhyChooseYummyController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public WhyChooseYummyController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> WhyChooseYummyList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/Services");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultWhyChooseYummyDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> WhyChooseYummyCreate()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/Services");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultWhyChooseYummyDto>>(jsonData);
				if (values != null && values.Count >= 3)
				{
					return RedirectToAction("WhyChooseYummyList");
				}
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> WhyChooseYummyCreate(CreateWhyChooseYummyDto createWhyChooseYummyDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createWhyChooseYummyDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7246/api/Services", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("WhyChooseYummyList");
			}
			return View();
		}


		public async Task<IActionResult> WhyChooseYummyDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7246/api/Services/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("WhyChooseYummyList");
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> WhyChooseYummyUpdate(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7246/api/Services/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateWhyChooseYummyDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> WhyChooseYummyUpdate(UpdateWhyChooseYummyDto updateWhyChooseYummyDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateWhyChooseYummyDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7246/api/Services", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("WhyChooseYummyList");
			}
			return View();
		}
	}
}
