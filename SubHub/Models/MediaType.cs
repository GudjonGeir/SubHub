using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class MediaType
    {
        public int Id { get; set; }
        [Display(Name = "Týpa")]
        public string Type { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
    }
}