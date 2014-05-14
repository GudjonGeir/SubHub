using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class Media
    {
        public int Id { get; set; }
        [Display(Name = "Útgáfudagur")]
        public DateTime DateAired { get; set; }
        public string PosterUrl { get; set; }
        [Display(Name = "Nafn")]
        public string Name { get; set; }
        [Display(Name = "Imdb Hlekkur")]
        public string ImdbUrl { get; set; }
        public int TypeId { get; set; }
        [Display(Name = "Flokkur")]
        public int GenreId { get; set; }
        public int DownloadCount { get; set; }
        [Display(Name = "Flokkur")]
        public virtual MediaGenre Genre { get; set; }
        [Display(Name = "Týpa")]
        public virtual MediaType Type { get; set; }
        [Display(Name = "Tungumál")]
        public virtual ICollection<Subtitle> Subtitles { get; set; }


        public Media()
        {
            Subtitles = new List<Subtitle>();
            
        }
    }
}