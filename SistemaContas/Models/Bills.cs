using SistemaContas.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaContas.Models
{
    public class Bills
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string? Value { get; set; }
        public Enums Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
