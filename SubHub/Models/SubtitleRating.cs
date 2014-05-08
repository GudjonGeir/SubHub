using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class SubtitleRating
    {
        [Key, ForeignKey("Subtitle")]
        public          int                          SubtitleId  { get; set; }
        public          int                          Count       { get; set; }    
        public virtual  Subtitle                     Subtitle    { get; set; }   // Corresponding subtitle for the rating
        public virtual  ICollection<ApplicationUser> Users       { get; set; }
    }
}