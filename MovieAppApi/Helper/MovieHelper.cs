using MovieAppApi.Model;
using Newtonsoft.Json;
using System.Net;

namespace MovieAppApi.Helper
{
    public class MovieHelper
    {
        public static String GetMovieIdFromUrl(String MovieURL)
        {

            String tobeSearched = "title/";
            String temp = MovieURL.Substring(MovieURL.IndexOf(tobeSearched) + tobeSearched.Length);
            String result = temp.Split('/')[0];
            return result;

        }

        public static Movie getmovieinfo(string movieid)
        {
            //https://www.omdbapi.com/?i=tt0073195&apikey=50659c3f
            string api_key = "50659c3f";
            string omdbapi = "https://www.omdbapi.com/?i=" + movieid + "&apikey=" + api_key;
            string movieinfojson = new WebClient().DownloadString(omdbapi);
            dynamic jsonobj = JsonConvert.DeserializeObject<dynamic>(movieinfojson);

            String title = jsonobj["Title"];
            String year = jsonobj["Year"];
            String ratings = jsonobj["imdbRating"];
            String genre = jsonobj["Genre"];
            String plot = jsonobj["Plot"];
            String poster = jsonobj["Poster"];
            // Console.WriteLine(title);
            Movie movie = new Movie
            {
                Title = title,
                Year = year,
                Genre = genre,
                imdbRatings = ratings,
                Descriptions = plot,
                Poster = poster
            };
            return movie;

        }
    }
}
