using Movie.DataAccess.Repository;
using Movie.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DataAccess.Abstract
{
    public interface IMovieDAL : IGenericRepository<MovieModel>
    {
    }
}
