using Microsoft.EntityFrameworkCore;
using PerMonServer.Models;

namespace PerMonServer.DataStore.SQL
{
    public class SQLDataStoreService : IDataStoreService
    {
        private PerfMonDbContext _ctx;

        protected string GetUUID()
        {
            var guid = Guid.NewGuid();

            return guid.ToString();
        }
        public SQLDataStoreService(PerfMonDbContext context)
        {
            _ctx = context;
        }

        public async Task<Agent?> GetAgentAsync(string name)
        {
            return await _ctx.Agents.Where(a => a.Name == name).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Measure>> GetAgentMeasuresAsync(string name)
        {
            var measures = await _ctx.Measures.Where(m => m.Name == name).ToArrayAsync();
            return measures;
        }

        public async Task<IEnumerable<Agent>> GetAgentsAsync(string? device)
        {
            var query = _ctx.Agents.AsQueryable();
            if (!string.IsNullOrEmpty(device)) 
            {
                query = query.Where(q => q.Device.Contains(device));
            }

            return await query.ToArrayAsync();
        }


        public async Task SaveMeasuresAsync(IEnumerable<Measure> measures)
        {
            throw new NotImplementedException();
        }

        public async Task<Agent> SaveAgentAsync(Agent agent)
        {
            Agent dbEntity = null;
            if (string.IsNullOrEmpty(agent.UUID))
                dbEntity = new Agent { UUID = GetUUID() };
            else
                dbEntity = _ctx.Agents.Where(a => a.)

            
                
        }
    }
}
