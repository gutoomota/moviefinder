using System;
using System.Collections.Generic;
using System.Text;

namespace MovieFinder.Models
{

    public class MovieRequestBody
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public Movie[] results { get; set; }
    }

}
