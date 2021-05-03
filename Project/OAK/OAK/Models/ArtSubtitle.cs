#nullable disable

namespace OAK.Models
{
    public class ArtSubtitle
    {
        public long ID { get; set; }
        public short Number { get; set; }
        public byte[] Subtitle { get; set; }

        public long ArticleID { get; set; }

        public Article Article { get; set; }
    }
}