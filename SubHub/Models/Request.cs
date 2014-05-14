using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class Request
    {
        public         int             Id              { get; set; }
        [Display(Name = "Nafn")]
        public         string          Name            { get; set; }
        [Display(Name = "Dagsetning")]
        public         DateTime        DateSubmitted   { get; set; }
        [Display(Name = "Staða")]
        public         bool            Completed       { get; set; }
        public string UserId { get; set; }
        public int LanguageId { get; set; }
        public virtual SubtitleLanguage Language { get; set; }
        public virtual ApplicationUser User { get; set; }   
        public virtual RequestRating   RequestRating   { get; set; }   // Corresponding rating for the request
    }
}