using Movie.Entities.Entities;

namespace Movie.Business.Abstract
{
    public interface IMovieManager
    {
        Task<IEnumerable<MovieModel>> GetAllMovieAsync();
        Task<IEnumerable<MovieModel>> GetTrendingMoviesFrom();
        Task<MovieModel> GetByIdAsync(int id);
        Task<MovieModel> AddAsync(MovieModel movie);
        Task<bool> AddRangeAsync(List<MovieModel> movies);
        Task<MovieModel> UpdateAsync(MovieModel movie);
    }
}
