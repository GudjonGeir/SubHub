using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class SubtitleLine
    {
        public         int      Id          { get; set; }
        public         int      SubtitleId  { get; set; }

        [Display(Name = "Línu númer")]
        public         int      LineNumber  { get; set; }

        [Display(Name = "Tími línu")]
        public         string   Time        { get; set; }

        [Display(Name = "Texti eitt")]
        public         string   LineOne     { get; set; }

        [Display(Name = "Texti tvö")]
        public         string   LineTwo     { get; set; }     
        public virtual Subtitle Subtitle    { get; set; } // Corresponding subtitle for the line
    }
}