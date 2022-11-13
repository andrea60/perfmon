using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business
{
    public interface IUnitOfWork
    {
        Task DiscardAsync();
        Task CommitAsync();
    }
}
