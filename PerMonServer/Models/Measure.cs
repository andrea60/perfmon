using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerMonServer.Models
{
    public class Measure
    {
        [Key]
        public string UUID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        [ForeignKey("")]
        public string AgentUUID { get; set; }
    }
}
