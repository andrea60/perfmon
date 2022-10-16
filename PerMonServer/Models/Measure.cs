using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerMonServer.Models
{
    public class Measure
    {
        [Key]
        public string UUID { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Unit { get; set; } = string.Empty;
        [Required]
        public string AgentUUID { get; set; }
        [ForeignKey("AgentUUID")]
        public virtual Agent Agent { get; set; }
    }
}
