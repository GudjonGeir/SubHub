using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class MediaGenre
    {
        public int Id { get; set; }
        [Display(Name = "Flokkur")]
        public string Genre { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
    }
}