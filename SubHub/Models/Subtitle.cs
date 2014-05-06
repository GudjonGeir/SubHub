using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class Subtitle
    {
        public          int                         Id              { get; set; }
        public          string                      Language        { get; set; }
        public          string                      Type            { get; set; }
        public          string                      Genre           { get; set; }
        public          string                      Name            { get; set; }
        public          string                      ImdbUrl         { get; set; }
        public          DateTime                    DateSubmitted   { get; set; }
        public          DateTime                    DateAired       { get; set; }
        public          string                      PosterUrl       { get; set; }
        // public virtual  ICollection<User>           Users           { get; set; }   // Users who have edited the file
        public virtual  ICollection<SubtitleLine>   SubtitleLines   { get; set; }   // Subtitle lines in the file
        public virtual  SubtitleRating              SubtitleRating  { get; set; }   // Corresponding rating for the file
    }
}