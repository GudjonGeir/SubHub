using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SubHub.Models
{
    public class Subtitle
    {
        public          int                          Id              { get; set; }
        [Display(Name = "Dagsetning")]
        public          DateTime                     DateSubmitted   { get; set; }
        public          int                          LanguageId      { get; set; }
        public          int                          MediaId         { get; set; }

        [Display(Name = "Tungumál")]
        public virtual  SubtitleLanguage             Language        { get; set; }
        public virtual  Media                        Media           { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }   // Users who have edited the file
        public virtual  ICollection<SubtitleLine>    SubtitleLines   { get; set; }   // Subtitle lines in the file
        public virtual  ICollection<Comment>         Comments        { get; set; }
        public virtual  SubtitleRating               SubtitleRating  { get; set; }   // Corresponding rating for the file


        public Subtitle()
        {
            DateSubmitted = DateTime.Now;
            //Users = new List<ApplicationUser>();
            //SubtitleLines = new List<SubtitleLine>();
            //Comments = new List<Comment>();
            //SubtitleRating = new SubtitleRating();
        }
    }
}