using PerMonServer.Models;

namespace PerMonServer.DataStore
{
    public interface IDataStoreService
    {
        /// <summary>
        /// Register an agent to the registry
        /// </summary>
        /// <param name="name">Name of the agent</param>
        /// <param name="device">Device monitored by this agent</param>
        /// <param name="measures">List of measures monitored by this agent</param>
        /// <returns>The UUID of the agent</returns>
        Task<string> RegisterAgentAsync(string name, string device, IEnumerable<Measure> measures);

        /// <summary>
        /// Returns a single agent
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Agent> GetAgentAsync(string name);
        
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
