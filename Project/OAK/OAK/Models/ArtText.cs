#nullable disable

namespace OAK.Models
{
    public class ArtText
    {
        public long ID { get; set; }
        public short Number { get; set; }
        public byte[] Text { get; set; }

        public long ArticleID { get; set; }

        public Article Article { get; set; }
    }
}