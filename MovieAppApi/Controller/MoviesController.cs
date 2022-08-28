using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAppApi.DAL;
using MovieAppApi.Dtos;
using MovieAppApi.Helper;
using MovieAppApi.Model;

namespace MovieAppApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/movies
        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "impactlevel", "pii" })]
        public ActionResult<IEnumerable<MovieReadDtos>> GetAllMovies()
        {
            var movies = _repository.GetAllMovies();
            return Ok(_mapper.Map< IEnumerable<MovieReadDtos>>(movies));
        }

        //GET api/movies/{id}
        [HttpGet("{id}", Name = "GetMovieById")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "impactlevel", "pii" })]
        public ActionResult<MovieReadDtos> GetMovieById(int id)
        {
            var movie = _repository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MovieReadDtos>(movie));
        }


        //POST api/movies
        [HttpPost]
        public ActionResult<MovieReadDtos> Create(URLDtos urldto)
        {
            String movieId = MovieHelper.GetMovieIdFromUrl(urldto.Url);
            Movie newMovie = MovieHelper.getmovieinfo(movieId);
            
            _repository.CreateMovie(newMovie);
            _repository.SaveChanges();
            var movieReadDto = _mapper.Map<MovieReadDtos>(newMovie);
            return CreatedAtRoute(nameof(GetMovieById), new { Id = movieReadDto.Id }, movieReadDto);

        }


        ////POST api/movies
        //[HttpPost]
        //public ActionResult<MovieReadDtos> CreateMovie(MovieCreateDtos moviecreatedtos)
        //{
        //    var movie = _mapper.Map<Movie>(moviecreatedtos);
        //    _repository.CreateMovie(movie);
        //    _repository.SaveChanges();

        //    var movieReadDto = _mapper.Map<MovieReadDtos>(movie);
        //    return CreatedAtRoute(nameof(GetMovieById), new { Id = movieReadDto.Id}, movieReadDto);

        //}
        //PUT api/movies/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, MovieUpdateDto movieupdatedto)
        {
            var movie = _repository.GetMovieById(id);
            if(movie == null)
            {
                return NotFound();
            }
            _mapper.Map(movieupdatedto, movie);
            _repository.UpdateMovie(movie);
            _repository.SaveChanges();
            return NoContent();

        }

        //DELETE api/movies/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var item = _repository.GetMovieById(id);
            if (item == null)
            {
                return NotFound();
            }
            _repository.DeleteMovie(item);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}
