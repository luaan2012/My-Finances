using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaContas.Models
{
    public class Earning
    {
        public int Id { get; set; }
        public string? EarningDay { get; set; }
        public double EarningYear { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
