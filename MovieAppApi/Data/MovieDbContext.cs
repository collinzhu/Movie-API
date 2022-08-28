using Microsoft.EntityFrameworkCore;
using MovieAppApi.Model;

namespace MovieAppApi.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> opt) : base(opt)
        {

        }

        public DbSet<Movie> Movies { get; set; }

    }
}
