using PerMonServer.Models;

namespace PerMonServer.DataStore
{
    public interface IDataStoreService
    {

        /// <summary>
        /// Saves an agent, upserting
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        Task<Agent> SaveAgentAsync(Agent agent);

        /// <summary>
        /// Upsert measures
        /// </summary>
        /// <param name="measures"></param>
        /// <returns></returns>
        Task SaveMeasuresAsync(IEnumerable<Measure> measures);

        /// <summary>
        /// Returns a single agent
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Agent?> GetAgentAsync(string name);
        
        /// <summary>
        /// Search for different agents
        /// </summary>
        /// <param name="device">Device monitored</param>
        /// <returns></returns>
        Task<IEnumerable<Agent>> GetAgentsAsync(string? device);

        /// <summary>
        /// Get all measures monitored by a single agent
        /// </summary>
        /// <param name="name">Name of the agent</param>
        /// <returns></returns>
        Task<IEnumerable<Measure>> GetAgentMeasuresAsync(string name);
    }
}
