﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionLifeTimes.Services
{
    public interface IService
    {
        string InstanceId { get; }
    }
}
