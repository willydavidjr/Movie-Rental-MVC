﻿using Emerson1.Models;
using Emerson1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Emerson1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            //base.Dispose(disposing);
        }
        public ActionResult Random()
        {
            Movie Shrek = new Movie() { Id = 1, Name = "Shrek Movie" };
            Customer john = new Customer() { Id = 1, Name = "John Paul" };
            Customer mat = new Customer() { Id = 2, Name = "Matthew" };
            List<Customer> customers = new List<Customer>();
            customers.Add(john);
            customers.Add(mat);
            RandomMovieViewModel viewModel = new RandomMovieViewModel()
            {
                Movie = Shrek,
                Customers = customers
            };

            return View(viewModel);
        }
        public ActionResult Index()
        {
            //IEnumerable<Movie> movies = GetMovies();
            IEnumerable<Movie> movies = _context.Movies.Include(y => y.Genre);
            return View(movies);
        }

        public ActionResult Details(int MovieID)
        {
            //Movie movie = GetMovies().Where(x => x.Id == MovieID).SingleOrDefault();
            Movie movie = _context.Movies.Where(x => x.Id == MovieID).SingleOrDefault();
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public IEnumerable<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie
                {
                    Id = 1,
                    Name = "Shrek"
                },
                new Movie
                {
                    Id=2,
                    Name="Chieffy"
                }
            };
            return movies;
        }
    }
}