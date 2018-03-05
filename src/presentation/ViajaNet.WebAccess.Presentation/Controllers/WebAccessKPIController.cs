namespace ViajaNet.WebAccess.Presentation.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ViajaNet.WebAccess.Application.Interfaces;
    using Microsoft.Extensions.Logging;

    [Route("api/web-access-kpi")]
    public class WebAccessKPIController : Controller
    {
        private readonly IWebAccessAppService webAccessAppService;
        private readonly ILogger<WebAccessKPIController> logger;

        public WebAccessKPIController(
            IWebAccessAppService webAccessAppService,
            ILogger<WebAccessKPIController> logger)
        {
            this.webAccessAppService = webAccessAppService;
            this.logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.webAccessAppService.GetKPI();
            this.logger.LogInformation("KPI gerado com sucesso");
            return Ok(result);
        }
    }
}