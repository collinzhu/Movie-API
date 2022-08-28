using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAppApi.Model
{
    public class Movie
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public string Title { get; set; }

        public string Year { get; set; }

        public string imdbRatings { get; set; }

        public string Poster { get; set; }

        public string Genre { get; set; }

        public string Descriptions { get; set; }

    }
}
