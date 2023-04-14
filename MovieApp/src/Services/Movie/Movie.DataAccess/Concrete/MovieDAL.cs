using Movie.DataAccess.Abstract;
using Movie.DataAccess.Repository;
using Movie.Entities.Entities;

namespace Movie.DataAccess.Concrete
{
    public class MovieDAL : GenericRepository<MovieModel>, IMovieDAL
    {
        public MovieDAL(AppDbContext context) : base(context)
        {
        }
    }
}
