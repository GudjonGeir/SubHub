using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class Request
    {
        public         int             Id              { get; set; }
        public         string          Name            { get; set; }
        public         DateTime        DateSubmitted   { get; set; }
        public         bool            Completed       { get; set; }
        public string UserId { get; set; }
        public int LanguageId { get; set; }
        public virtual SubtitleLanguage Language { get; set; }
        public virtual ApplicationUser User { get; set; }   
        public virtual RequestRating   RequestRating   { get; set; }   // Corresponding rating for the request
    }
}