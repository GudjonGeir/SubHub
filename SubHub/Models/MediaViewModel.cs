using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubHub.Models
{
    public class MediaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Útgáfudagur")]
        [DataType(DataType.Date)]
        public DateTime DateAired { get; set; }

        [Display(Name = "Myndahlekkur")]
        public string PosterUrl { get; set; }

        [Required(ErrorMessage="This Field is required")]
        [Display(Name = "Nafn")]
        public string Name { get; set; }

        [Display(Name = "Imdb Hlekkur")]
        public string ImdbUrl { get; set; }

        [Display(Name = "Týpa")]
        public int TypeId { get; set; }

        [Display(Name = "Flokkur")]
        public int GenreId { get; set; }

        [Display(Name = "Flokkur")]
        public virtual MediaGenre Genre { get; set; }

        [Display(Name = "Týpa")]
        public virtual MediaType Type { get; set; }

        public List<SelectListItem> MediaTypes { get; set; }

        public List<SelectListItem> MediaGenres { get; set; }

        [Display(Name = "Tungumál")]
        public List<SelectListItem> SubtitleLanguages { get; set; }

        public string SelectedLanguage { get; set; }
       
        public MediaViewModel()
        {
            DateAired = DateTime.Now;
        }
    }
}