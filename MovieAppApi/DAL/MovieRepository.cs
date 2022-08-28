using Microsoft.EntityFrameworkCore;
using MovieAppApi.Data;
using MovieAppApi.Model;

namespace MovieAppApi.DAL
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(p => p.Id == id);
        }

  

        public void UpdateMovie(Movie movie)
        {
           //context.Entry(movie).State = EntityState.Modified;
        }

        public void CreateMovie(Movie movie)
        {
            if(movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            _context.Movies.Add(movie);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

     

        public void DeleteMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            _context.Movies.Remove(movie);
        }
    }
}
