namespace ViajaNet.WebAccess.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ViajaNet.WebAccess.Application.Interfaces;
    using ViajaNet.WebAccess.Application.ViewModel;

    [Route("api/[controller]")]
    public class WebAccessController : Controller
    {
        private readonly IWebAccessAppService webAccessAppService;

        public WebAccessController(IWebAccessAppService webAccessAppService)
        {
            this.webAccessAppService = webAccessAppService;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] WebAccessViewModel webAccessViewModel)
        {
            if (ModelState.IsValid)
            {
                this.webAccessAppService.Register(webAccessViewModel);
                return Ok();
            }

            return BadRequest();
        }
    }
}
