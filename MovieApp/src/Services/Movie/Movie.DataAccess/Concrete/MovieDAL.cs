using Microsoft.EntityFrameworkCore;
using Movie.DataAccess.Abstract;
using Movie.DataAccess.Repository;
using Movie.Entities.Common;
using Movie.Entities.Entities;

namespace Movie.DataAccess.Concrete
{
    public class MovieDAL : GenericRepository<MovieModel>, IMovieDAL
    {
        public MovieDAL(AppDbContext context) : base(context)
        {
        }

        public async Task<PaginationResponse<MovieModel>> GetAllPaginationAsync(PaginationRequest pagination)
        {
            var result = await _context.Movies.AsNoTracking().Skip((pagination.PageIndex - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();
            var count = await _context.Movies.CountAsync();
            var pagedData = new PaginationResponse<MovieModel>()
            {
                Page = pagination.PageIndex,
                PageSize = pagination.PageSize,
                Results = result,
                Total_results = count,
                Total_pages = count / pagination.PageSize
            };
            return pagedData;
        }
    }
}
