using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class SubtitleLanguage
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public virtual ICollection<Subtitle> Subtitles { get; set; }
    }
}