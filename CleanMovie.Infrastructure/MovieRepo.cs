using CleanMovie.Application;
using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public class MovieRepo : IMovieRepo
    {
        private readonly MovieDbContext _movieDbContext;

        public MovieRepo(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public Movie createMovie(Movie movie)
        {
            _movieDbContext.Movies.Add(movie);
            _movieDbContext.SaveChanges();
            return movie;
        }

        public List<Movie> getAllMovie()
        {
            return _movieDbContext.Movies.ToList();
        }
    }
}
