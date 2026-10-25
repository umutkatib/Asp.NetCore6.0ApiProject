using ApiProjectCamp.WebUI.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjectCamp.WebUI.Controllers
{
	public class FeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> FeatureList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/Features");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		// eğer 1 kayıt varsa kullanıcının url'den sayfaya erişmesi engeller
		[HttpGet]
		public async Task<IActionResult> FeatureCreate()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/Features");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				if (values != null && values.Any())
				{
					return RedirectToAction("FeatureList");
				}
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> FeatureCreate(CreateFeatureDto createFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7246/api/Features", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("FeatureList");
			}

			ViewBag.Error = await responseMessage.Content.ReadAsStringAsync();
			return View(createFeatureDto);
		}


		public async Task<IActionResult> FeatureDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7246/api/Features/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("FeatureList");
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> FeatureUpdate(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7246/api/Features/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> FeatureUpdate(UpdateFeatureDto updateFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7246/api/Features", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("FeatureList");
			}
			return View();
		}

		//public async Task<IActionResult> FeatureChangeStatus(int id)
		//{
		//	var client = _httpClientFactory.CreateClient();
		//	var responseMessage = await client.GetAsync($"https://localhost:7246/api/Features/FeatureChangeStatus/{id}");
		//	return RedirectToAction("FeatureList");
		//}
	}
}
