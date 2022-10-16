using System.ComponentModel.DataAnnotations;

namespace PerMonServer.Models
{
    public class Measure
    {
        [Key]
        public string UUID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
    }
}
