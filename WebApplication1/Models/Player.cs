﻿namespace WebApplication1.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public int age { get; set; }
        public  int? PlayerId { get; set; }
        public Team? Team { get; set; }

    }
}
