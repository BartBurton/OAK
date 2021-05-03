#nullable disable

namespace OAK.Models
{
    public class ArtImage
    {
        public long ID { get; set; }
        public short Number { get; set; }
        public byte[] Image { get; set; }

        public long ArticleID { get; set; }

        public Article Article { get; set; }
    }
}