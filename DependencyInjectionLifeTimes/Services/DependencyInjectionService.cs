using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionLifeTimes.Services
{
    public class DependencyInjectionService: ISingletonService,IScopedService, ITransientService
    {
        public string InstanceId { get; } = Guid.NewGuid().ToString();
    }
}
