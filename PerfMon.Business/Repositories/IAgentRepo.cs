using PerfMon.Business.Models.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Repositories
{
    public interface IAgentRepo : IRepo<Agent>
    {
        Task<Agent> GetOne(string name);
    }
}
