using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movie.Business.Abstract;
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
                var aa = await GetTrendingMovies();
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task<IEnumerable<MovieModel>> GetTrendingMovies()
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IMovieManager>();
                var result = await service.GetTrendingMoviesFrom();

                return result;
            }
        }
    }
}
