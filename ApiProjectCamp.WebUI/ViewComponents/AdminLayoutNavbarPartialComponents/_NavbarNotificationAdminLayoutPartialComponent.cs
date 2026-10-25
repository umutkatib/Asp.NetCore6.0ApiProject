using ApiProjectCamp.WebUI.Dtos.NotificationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApiProjectCamp.WebUI.ViewComponents.AdminLayoutNavbarPartialComponents
{
	public class _NavbarNotificationAdminLayoutPartialComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _NavbarNotificationAdminLayoutPartialComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7246/api/Notifications");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
