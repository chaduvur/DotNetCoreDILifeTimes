using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionLifeTimes.Services
{
    public class InternalService : IInternalService
    {
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;
        private readonly ILogger<InternalService> _logger;

        public InternalService(ILogger<InternalService> logger, IScopedService scopedService,ITransientService transientService) {

            _logger = logger;
            _scopedService = scopedService ?? throw new ArgumentNullException(nameof(scopedService));
            _transientService = transientService ?? throw new ArgumentNullException(nameof(transientService));
        }
        public void print()
        {
            _logger.LogInformation("Scoped "+_scopedService.InstanceId);
            _logger.LogInformation("Transient " + _transientService.InstanceId);
        }
    }
}
