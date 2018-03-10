using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MovieFinder.Models;

namespace MovieFinder.Service
{
    public static class DataService
    {
        public const string baseUrl = "https://api.themoviedb.org/3/";
        public const string imageUrl = "https://image.tmdb.org/t/p/";
        public const string api_key = "1f54bd990f1cdfb230adb312546d765d";

        public static bool connected;

        public static List<Movie> movies;
        public static List<Genre> genres;

        public static Movie selectedMovie;

        public static string log;

        public static int totalRequestPages;

        public static void Init()
        {
            totalRequestPages = 1;
            movies = new List<Movie>();
            genres = new List<Genre>();
        }

        public async static Task GetGenres(CancellationToken ct)
        {
            ConnectionDataService T = new ConnectionDataService();
            await T.GetGenres(ct);
        }

        public async static Task<string> GetMovies(CancellationToken ct, int page, string requestKey)
        {
            ConnectionDataService T = new ConnectionDataService();

            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            await T.GetMovies(ct, page, date);

            return requestKey;
        }

        public async static Task<string> GetMoviesByQuery(CancellationToken ct, int page, string query, string requestKey)
        {
            ConnectionDataService T = new ConnectionDataService();

            await T.getMoviesByQuery(ct, page, query);

            return requestKey;
        }
    }
}
