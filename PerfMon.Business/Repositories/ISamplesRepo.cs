using PerfMon.Business.Models.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Repositories
{
    public interface ISamplesRepo
    {
        Task RegisterSampleAsync(Sample sample);

        Task DeleteSamplesAsync(Guid measureID);
    }
}
