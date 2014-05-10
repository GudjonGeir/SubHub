using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SubHub.Models
{
    public class SubtitleViewModel
    {
        public int Id { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int LanguageId { get; set; }
        public int MediaId { get; set; }
        public virtual SubtitleLanguage Language { get; set; }
        public virtual Media Media { get; set; }
        public List<SelectListItem> SubtitleLanguages { get; set; }

        public HttpPostedFileBase SrtUpload { get; set; }

        public SubtitleViewModel()
        {
            DateSubmitted = DateTime.Now;
        }
    }
}