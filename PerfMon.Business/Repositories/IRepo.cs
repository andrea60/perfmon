using PerfMon.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Repositories
{
    public interface IRepo<T> where T:IAggregateRoot
    {
        Task AddAsync(T item);

        Task RemoveAsync(T item);

        Task UpdateAsync(T item);
    }
}
