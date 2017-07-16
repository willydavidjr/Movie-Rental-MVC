using Emerson1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emerson1.ViewModels
{
    public class NewMoviesViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Movie Movie { get; set; }
    }
}