using ApiProjectCamp.WebUI.Dtos.YummyEventDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiProjectCamp.WebUI.ViewComponents
{
	public class _EventDefaultPartialComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _EventDefaultPartialComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/YummyEvents/YummyEventActiveList");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultYummyEventDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
