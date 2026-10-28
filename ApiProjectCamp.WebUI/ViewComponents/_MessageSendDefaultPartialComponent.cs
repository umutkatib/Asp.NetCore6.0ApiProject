using ApiProjectCamp.WebUI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebUI.ViewComponents
{
	public class _MessageSendDefaultPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(new CreateMessageDto());
		}
	}
}
