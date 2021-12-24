using System;

namespace exampleEntityFrameworkCoreMemory.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
    }
}