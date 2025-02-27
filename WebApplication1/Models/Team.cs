namespace WebApplication1.Models
{
    public class Team
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public List<Player> Players { get; set; } = new List<Player>();

    }
}
