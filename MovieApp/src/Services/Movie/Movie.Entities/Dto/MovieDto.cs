using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Entities.Dto
{
    public class MovieDto
    {
        public bool Adult { get; set; }
        public string? BackdropPath { get; set; }
        public string? BelongsToCollection { get; set; }
        public long Budget { get; set; }
        public string? Homepage { get; set; }
        public string? ImdbId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public double Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? ReleaseDate { get; set; }
        public long Revenue { get; set; }
        public long Runtime { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }
        public string? Title { get; set; }
        public bool Video { get; set; }
        public long VoteAverage { get; set; }
        public long VoteCount { get; set; }
    }
}
