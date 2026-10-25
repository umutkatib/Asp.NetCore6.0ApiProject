using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebUI.ViewComponents.AdminLayoutPartialComponent
{
	public class _NavbarAdminLayoutPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();	
		}
	}
}
