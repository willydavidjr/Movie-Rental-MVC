using Emerson1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emerson1.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Movie> Movies { get; set; }
    }
}