using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SubHub.Models
{
    public class SubtitleViewModel
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }
        public string ImdbUrl { get; set; }
        public string PosterUrl { get; set; }
        public DateTime DateAired { get; set; }



        public HttpPostedFileBase SrtUpload { get; set; }

        public SubtitleViewModel()
        {
            DateAired = DateTime.Now;
        }
    }
}