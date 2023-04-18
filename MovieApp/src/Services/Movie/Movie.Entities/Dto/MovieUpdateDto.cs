using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Entities.Dto
{
    public class MovieUpdateDto
    {
        public int Id { get; set; }
        public string Note { get; set; }
        [Range(1,10, ErrorMessage = "Puan 1 ile 10 arasında olabilir.")]
        public int VoteCount { get; set; }
    }
}
