using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class MediaType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
    }
}