using Movie.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Entities.Entities
{
    public class MovieModel : EntityBase
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public string Title { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string MediaType { get; set; }
        public List<long> GenreIds { get; set; }
        public double Popularity { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public long VoteCount { get; set; }
    }
}
