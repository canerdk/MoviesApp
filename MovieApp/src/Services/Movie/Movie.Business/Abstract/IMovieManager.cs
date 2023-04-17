using Movie.Entities.Common;
using Movie.Entities.Dto;
using Movie.Entities.Entities;

namespace Movie.Business.Abstract
{
    public interface IMovieManager
    {
        Task<IEnumerable<MovieModel>> GetAllMovieAsync();
        Task<MovieModel> GetByIdAsync(long id);
        Task<MovieModel> AddAsync(MovieModel movie);
        Task<bool> AddRangeAsync(List<MovieModel> movies);
        Task<MovieModel> UpdateAsync(MovieModel movie);

        Task<MovieDto> GetLastMovieFromTMBD();
        Task<PaginationResponse<MovieDto>> GetPopularMoviesFromTMBD();

    }
}
