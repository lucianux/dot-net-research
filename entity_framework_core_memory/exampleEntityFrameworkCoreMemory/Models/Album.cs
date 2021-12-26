using System;

namespace exampleEntityFrameworkCoreMemory.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
    }
}