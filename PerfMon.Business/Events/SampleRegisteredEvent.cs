﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Events
{
    public record SampleRegisteredEvent : INotification;
  
}
