using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Models.Agent.Exceptions
{
    /// <summary>
    /// Describes when a measure is being re-registered with incompatible configurations (same name, different types)
    /// </summary>
    public class IncompatibleMeasureException : InvalidOperationException
    {
        public string PropertyName { get; private set; }

        public IncompatibleMeasureException(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
