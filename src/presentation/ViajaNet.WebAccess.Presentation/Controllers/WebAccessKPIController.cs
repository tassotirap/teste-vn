using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajaNet.WebAccess.Application.Interfaces;
using ViajaNet.WebAccess.Application.ViewModel;

namespace ViajaNet.WebAccess.Presentation.Controllers
{
    [Route("api/web-access-kpi")]
    public class WebAccessKPIController : Controller
    {
        private readonly IWebAccessAppService webAccessAppService;

        public WebAccessKPIController(IWebAccessAppService webAccessAppService)
        {
            this.webAccessAppService = webAccessAppService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.webAccessAppService.GetKPI();
            return Ok(result);
        }
    }
}