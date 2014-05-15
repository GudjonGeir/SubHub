using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class Comment
    {
        public         int             Id            { get; set; }
        public         string          UserId        { get; set; }
        public         int             SubtitleId    { get; set; }
        public         string          CommentText   { get; set; }
        public         DateTime        DateSubmitted { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required]
        public virtual Subtitle        Subtitle      { get; set; }

    }
}