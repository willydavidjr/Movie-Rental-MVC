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
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name="Number of Stocks")]
        public int NumberOfStocks { get; set; }
        public Genre Genre { get; set; }
        [Display(Name="Genre")]
        public byte GenreId { get; set; }
    }
}