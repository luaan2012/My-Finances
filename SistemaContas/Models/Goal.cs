using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaContas.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? ValueGoal { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
