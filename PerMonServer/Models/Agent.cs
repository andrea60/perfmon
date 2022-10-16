using System.ComponentModel.DataAnnotations;

namespace PerMonServer.Models
{
    public class Agent
    {
        [Key]
        public string UUID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Device { get; set; } = string.Empty;
        public DateTime? LastSeen { get; set; }
    }
}
