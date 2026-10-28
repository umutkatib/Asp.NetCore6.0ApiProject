using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebUI.ViewComponents.DashboardAdminPartialComponents
{
	public class _DashboardWidgetsAdminLayoutPartialComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashboardWidgetsAdminLayoutPartialComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			int r1, r2, r3, r4;
			Random rnd = new Random();
			r1 = rnd.Next(1, 35);
			r2 = rnd.Next(1, 35);
			r3 = rnd.Next(1, 35);
			r4 = rnd.Next(1, 35);
			var client1 = _httpClientFactory.CreateClient();
			var responseMessage1 = await client1.GetAsync("https://localhost:7246/api/Reservations/ReservationGetTotalCount");
			var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
			ViewBag.ReservationCount1 = jsonData1;
			ViewBag.ReservationCount1p = r1;

			var client2 = _httpClientFactory.CreateClient();
			var responseMessage2 = await client1.GetAsync("https://localhost:7246/api/Reservations/CustomerGetTotalCount");
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
			ViewBag.ReservationCount2 = jsonData2;
			ViewBag.ReservationCount2p = r2;

			var client3 = _httpClientFactory.CreateClient();
			var responseMessage3 = await client3.GetAsync("https://localhost:7246/api/Reservations/ReservationGetPendingCount");
			var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
			ViewBag.ReservationCount3 = jsonData3;
			ViewBag.ReservationCount3p = r3;

			var client4 = _httpClientFactory.CreateClient();
			var responseMessage4 = await client4.GetAsync("https://localhost:7246/api/Reservations/ReservationGetApprovedCount");
			var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
			ViewBag.ReservationCount4 = jsonData4;
			ViewBag.ReservationCount4p = r4;
			return View();
		}
	}
}
