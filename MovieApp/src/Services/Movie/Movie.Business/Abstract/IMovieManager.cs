using Movie.Entities.Common;
using Movie.Entities.Dto;
using Movie.Entities.Entities;

namespace Movie.Business.Abstract
{
    public interface IMovieManager
    {
        Task<PaginationResponse<MovieModel>> GetAllMovieAsync(PaginationRequest pagination);
        Task<MovieModel> GetByIdAsync(long id);
        Task<MovieModel> AddAsync(MovieModel movie);
        Task<bool> AddRangeAsync(List<MovieModel> movies);
        Task<MovieModel> UpdateAsync(MovieUpdateDto movie, int id);

        Task<MovieDto> GetLastMovieFromTMBD();
        Task<PaginationResponse<MovieDto>> GetPopularMoviesFromTMBD(int page);

    }
}
