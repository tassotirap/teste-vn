namespace ViajaNet.WebAccess.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ViajaNet.WebAccess.Application.Interfaces;
    using ViajaNet.WebAccess.Application.ViewModel;

    [Route("api/web-access")]
    public class WebAccessController : Controller
    {
        private readonly IWebAccessAppService webAccessAppService;
        private readonly ILogger<WebAccessController> logger;

        public WebAccessController(
            IWebAccessAppService webAccessAppService,
            ILogger<WebAccessController> logger)
        {
            this.webAccessAppService = webAccessAppService;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] WebAccessViewModel webAccessViewModel)
        {
            if (ModelState.IsValid)
            {
                this.webAccessAppService.Register(webAccessViewModel);
                this.logger.LogInformation("Registrado com sucesso");
                return Ok("Inserido com sucesso.");
            }
            this.logger.LogWarning("Invalid Request");
            return BadRequest(ModelState);
        }
    }
}
