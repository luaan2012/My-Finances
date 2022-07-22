namespace SistemaContas.Models
{
    public class Remember
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Hour { get; set; }
        public string? Text { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
