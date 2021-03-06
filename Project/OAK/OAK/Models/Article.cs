﻿using System;
using System.Collections.Generic;

#nullable disable

namespace OAK.Models
{
    public class Article
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; } = 0;
        public int LikesCount { get; set; } = 0;

        public long? AutorID { get; set; }
        public long SectionID { get; set; }

        public ICollection<Autor> Likes { get; set; }

        public Autor Autor { get; set; }
        public Section Section { get; set; }
        public ICollection<ArtImage> ArtImages { get; set; }
        public ICollection<ArtSubtitle> ArtSubtitles { get; set; }
        public ICollection<ArtText> ArtTexts { get; set; }
    }
}