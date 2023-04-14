using Movie.Entities.Entities;

namespace Movie.Business.Abstract
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieModel>> GetAllMovieAsync();
        Task<MovieModel> GetByIdAsync(int id);
        Task<MovieModel> AddAsync(MovieModel movie);
        Task<MovieModel> AddRangeAsync(List<MovieModel> movies);
        Task<MovieModel> UpdateAsync(MovieModel movie);
    }
}
