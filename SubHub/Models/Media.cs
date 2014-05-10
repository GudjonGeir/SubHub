using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class Media
    {
        public int Id { get; set; }
        public DateTime DateAired { get; set; }
        public string PosterUrl { get; set; }
        public string Name { get; set; }
        public string ImdbUrl { get; set; }
        public int TypeId { get; set; }
        public int GenreId { get; set; }
        public virtual MediaGenre Genre { get; set; }
        public virtual MediaType Type { get; set; }
        public virtual ICollection<Subtitle> Subtitles { get; set; }

        public Media()
        {
            Subtitles = new List<Subtitle>();
        }
    }
}