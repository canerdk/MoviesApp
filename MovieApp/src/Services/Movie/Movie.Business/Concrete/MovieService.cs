using Movie.Business.Abstract;
using Movie.DataAccess.Abstract;
using Movie.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Concrete
{
    public class MovieManager : IMovieManager
    {
        private readonly IMovieDAL _movieDAL;

        public MovieManager(IMovieDAL movieDAL)
        {
            _movieDAL = movieDAL;
        }

        public Task<MovieModel> AddAsync(MovieModel movie)
        {
            throw new NotImplementedException();
        }

        public Task<MovieModel> AddRangeAsync(List<MovieModel> movies)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieModel>> GetAllMovieAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MovieModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieModel> UpdateAsync(MovieModel movie)
        {
            throw new NotImplementedException();
        }
    }
}
