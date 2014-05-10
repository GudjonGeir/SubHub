using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class MediaGenre
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
    }
}