using ApiProjectCamp.WebUI.Dtos.ChefDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjectCamp.WebUI.Controllers
{
	public class ChefController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ChefController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> ChefList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/Chefs");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult ChefCreate()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ChefCreate(CreateChefDto createChefDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createChefDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7246/api/Chefs", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ChefList");
			}
			return View();
		}


		public async Task<IActionResult> ChefDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7246/api/Chefs/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ChefList");
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> ChefUpdate(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7246/api/Chefs/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateChefDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ChefUpdate(UpdateChefDto updateChefDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateChefDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7246/api/Chefs", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ChefList");
			}
			return View();
		}

		public async Task<IActionResult> ChefChangeStatus(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7246/api/Chefs/ChefChangeStatus/{id}");
			return RedirectToAction("ChefList");
		}
	}
}
