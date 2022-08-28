using MovieAppApi.Model;

namespace MovieAppApi.DAL
{
    public interface  IMovieRepository
    {
        bool SaveChanges();
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);

        void DeleteMovie(Movie movie);

        void UpdateMovie(Movie movie);

        void CreateMovie(Movie movie);

    }
}
