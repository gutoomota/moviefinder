using MovieFinder.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieFinder.Service
{
    public class ConnectionDataService
    {
        public async Task GetGenres(CancellationToken ct)
        {
            string Url = DataService.baseUrl + "genre/movie/list?api_key=" 
                + DataService.api_key + "&language=en-US";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(Url, ct);

            var JsonResult = response.Content.ReadAsStringAsync().Result;

            GenreRequestBody genreRequestBody = JsonConvert.DeserializeObject<GenreRequestBody>(JsonResult);

            DataService.connected = true;

            DataService.genres.AddRange(genreRequestBody.genres);
        }

        public async Task GetMovies(CancellationToken ct, int page, string date)
        {
            string Url = DataService.baseUrl + "discover/movie?api_key=" + DataService.api_key +
                "&language=en-US&sort_by=primary_release_date.asc&include_adult=false&include_video=false&page=" +
                page + "&primary_release_date.gte=" + date;

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(Url, ct);

            var JsonResult = response.Content.ReadAsStringAsync().Result;

            MovieRequestBody movieRequestBody = JsonConvert.DeserializeObject<MovieRequestBody>(JsonResult);
            DataService.totalRequestPages = movieRequestBody.total_pages;

            DataService.connected = true;

            DataService.movies = new List<Movie>();
            DataService.movies.AddRange(movieRequestBody.results);

            DataService.log = Url;
        }

        public async Task getMoviesByQuery(CancellationToken ct, int page, string query)
        {
            string Url = DataService.baseUrl + "search/movie?api_key=" + DataService.api_key +
                "&language=en-US&&query=" + query + "&page=" + page + "&include_adult=false";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(Url, ct);

            var JsonResult = response.Content.ReadAsStringAsync().Result;

            MovieRequestBody movieRequestBody = JsonConvert.DeserializeObject<MovieRequestBody>(JsonResult);
            DataService.totalRequestPages = movieRequestBody.total_pages;

            DataService.connected = true;

            DataService.movies = new List<Movie>();
            DataService.movies.AddRange(movieRequestBody.results);

            DataService.log = Url;
        }
    }
}
