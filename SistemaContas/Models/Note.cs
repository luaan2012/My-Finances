using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaContas.Models
{
    public class Note
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
    public class Note2
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
    public class Note3
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }

}
