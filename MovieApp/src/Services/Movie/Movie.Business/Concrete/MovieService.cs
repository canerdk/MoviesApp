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

        public async Task<MovieModel> AddAsync(MovieModel movie)
        {
            var result = await _movieDAL.AddAsync(movie);
            return result;
        }

        public async Task<bool> AddRangeAsync(List<MovieModel> movies)
        {
            var result = await _movieDAL.AddRangeAsync(movies);

            return result;
        }

        public async Task<IEnumerable<MovieModel>> GetAllMovieAsync()
        {
            var results = await _movieDAL.GetAllAsync();
            return results;
        }

        public async Task<MovieModel> GetByIdAsync(int id)
        {
            var result = await _movieDAL.GetAsync(x => x.Id == id);
            return result;
        }

        public async Task<MovieModel> UpdateAsync(MovieModel movie)
        {
            var exist = await GetByIdAsync(movie.Id);
            if (exist != null)
            {
                var result = await _movieDAL.UpdateAsync(movie);
                return result;
            }

            return null;
        }
    }
}
