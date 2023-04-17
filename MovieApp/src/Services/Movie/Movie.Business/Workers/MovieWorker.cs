using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movie.Business.Abstract;
using Movie.Entities.Common;
using Movie.Entities.Dto;
using Movie.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.Workers
{
    public class MovieWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public MovieWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var movies = await GetTrendingMovies();
                if(movies.results.Count > 0)
                {
                    await AddRangeAsync(movies.results);
                }
                await Task.Delay(10000, stoppingToken);
            }
        }

        private async Task<PaginationResponse<MovieDto>> GetTrendingMovies()
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IMovieManager>();
                var result = await service.GetPopularMoviesFromTMBD();

                return result;
            }
        }

        private async Task<bool> AddRangeAsync(List<MovieModel> models)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IMovieManager>();
                var result = await service.AddRangeAsync(models);
                return result;
            }
        }
    }
}
