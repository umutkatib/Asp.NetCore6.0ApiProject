using ApiProjectCamp.WebUI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiProjectCamp.WebUI.ViewComponents.AdminLayoutNavbarPartialComponents
{
	public class _NavbarMessageListAdminLayoutPartialComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _NavbarMessageListAdminLayoutPartialComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/Messages/MessageListIsReadFalse");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultMessageListByReadFalseDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
