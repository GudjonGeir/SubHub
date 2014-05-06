using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class SubtitleLine
    {
        public         int      SubtitleId  { get; set; }
        public         int      LineNumber  { get; set; }
        public         string   Time        { get; set; }
        public         string   LineOne     { get; set; }
        public         string   LineTwo     { get; set; }     
        public virtual Subtitle Subtitle    { get; set; } // Corresponding subtitle for the line
    }
}