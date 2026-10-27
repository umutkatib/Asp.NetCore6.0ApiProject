using ApiProjectCamp.WebUI.Dtos.ImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjectCamp.WebUI.Controllers
{
	public class GalleryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public GalleryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> ImageList()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/Images");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultImageDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult ImageCreate()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ImageCreate(CreateImageDto createImageDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createImageDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7246/api/Images", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ImageList");
			}
			return View();
		}


		public async Task<IActionResult> ImageDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7246/api/Images/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ImageList");
			}
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> ImageUpdate(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7246/api/Images/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateImageDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ImageUpdate(UpdateImageDto updateImageDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateImageDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7246/api/Images", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("ImageList");
			}
			return View();
		}
	}
}
