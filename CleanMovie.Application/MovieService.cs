using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepo _movieRepo;

        public MovieService(IMovieRepo movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public Movie createMovie(Movie movie)
        {
            _movieRepo.createMovie(movie);
            
            return movie;
        }

        public List<Movie> getAllMovie()
        {
            return _movieRepo.getAllMovie();
        }
    }
}
