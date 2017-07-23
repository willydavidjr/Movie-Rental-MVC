using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emerson1.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name="Number of Stocks")]
        [Range(1, 20)]
        public int NumberOfStocks { get; set; }
        public Genre Genre { get; set; }
        
        [Display(Name="Genre")]
        [Required]
        public byte GenreId { get; set; }
    }
}