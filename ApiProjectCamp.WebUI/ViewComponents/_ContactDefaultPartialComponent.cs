using ApiProjectCamp.WebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjectCamp.WebUI.ViewComponents
{
	public class _ContactDefaultPartialComponent :ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _ContactDefaultPartialComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/Contacts/");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
