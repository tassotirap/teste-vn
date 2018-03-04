namespace ViajaNet.WebAccess.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using ViajaNet.WebAccess.Application.Interfaces;
    using ViajaNet.WebAccess.Application.ViewModel;

    [Route("api/web-access")]
    public class WebAccessController : Controller
    {
        private readonly IWebAccessAppService webAccessAppService;

        public WebAccessController(IWebAccessAppService webAccessAppService)
        {
            this.webAccessAppService = webAccessAppService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] WebAccessViewModel webAccessViewModel)
        {
            if (ModelState.IsValid)
            {
                this.webAccessAppService.Register(webAccessViewModel);
                return Ok("Inserido com sucesso.");
            }

            return BadRequest(ModelState);
        }
    }
}
