using MovieFinder.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieFinder.Models
{
    public class Movie
    {
        public int vote_count { get; set; }
        public int id { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public string title { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public int[] genre_ids { get; set; }
        public string backdrop_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }

        public string ImageLink
        {
            get
            {
                return DataService.imageUrl + "w200/" + poster_path;
            }
            set { return; }
        }

        public string Genres
        {
            get
            {
                string genres = "";
                for (int i = 0; i < genre_ids.Length; i++)
                {
                    for (int j = 0; j < DataService.genres.Count; j++)
                    {
                        if (genre_ids[i] == DataService.genres[j].id)
                        {
                            if (i != genre_ids.Length - 1)
                                genres = genres + DataService.genres[j].name + " | ";
                            else
                                genres = genres + DataService.genres[j].name;
                            break;
                        }
                    }
                }
                if (genres.Length == 0)
                    return "none";

                return genres;
            }
        }
    }
}
