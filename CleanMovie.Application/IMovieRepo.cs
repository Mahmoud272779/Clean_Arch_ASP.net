using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Application
{
    public interface IMovieRepo
    {
        public List<Movie> getAllMovie();

        public Movie createMovie(Movie movie);
    }
}
