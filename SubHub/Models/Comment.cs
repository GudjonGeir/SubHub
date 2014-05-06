using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class Comment
    {
        public          int         Id              { get; set; }
        public          string      CommentText     { get; set; }
        public          DateTime    DateSubmitted   { get; set; }
        public          int         UserId          { get; set; }
    }
}