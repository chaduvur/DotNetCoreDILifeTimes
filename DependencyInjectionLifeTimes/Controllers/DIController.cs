using DependencyInjectionLifeTimes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionLifeTimes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DIController : ControllerBase
    {       
        private readonly ILogger<DIController> _logger;
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;
        private readonly IInternalService _internalService;

        public DIController(ILogger<DIController> logger,ISingletonService singletonService,IScopedService scopedService,ITransientService transientService,
            IInternalService internalService)
        {
            _logger = logger;
            _singletonService = singletonService ?? throw new ArgumentNullException(nameof(singletonService));
            _scopedService = scopedService ?? throw new ArgumentNullException(nameof(scopedService));
            _transientService = transientService ?? throw new ArgumentNullException(nameof(transientService));
            _internalService = internalService ?? throw new ArgumentNullException(nameof(internalService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Singleton : " + _singletonService.InstanceId);
            _logger.LogInformation("Scoped : "+ _scopedService.InstanceId);
            _logger.LogInformation("Transient : "+_transientService.InstanceId);

            _internalService.print();

            return Ok();
        }
    }
}
