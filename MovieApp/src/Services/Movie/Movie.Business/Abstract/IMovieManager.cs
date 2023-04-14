using Movie.Entities.Entities;

namespace Movie.Business.Abstract
{
    public interface IMovieManager
    {
        Task<IEnumerable<MovieModel>> GetAllMovieAsync();
        Task<MovieModel> GetByIdAsync(int id);
        Task<MovieModel> AddAsync(MovieModel movie);
        Task<MovieModel> AddRangeAsync(List<MovieModel> movies);
        Task<MovieModel> UpdateAsync(MovieModel movie);
    }
}
