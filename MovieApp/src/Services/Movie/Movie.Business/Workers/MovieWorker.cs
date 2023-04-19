using AutoMapper;
using EventBus.Events;
using MassTransit;
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
using System.Text.Json;
using System.Threading.Tasks;

namespace Movie.Business.Workers
{
    public class MovieWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private PeriodicTimer _timer = new(TimeSpan.FromMilliseconds(10000));
        private int page = 1;

        public MovieWorker(IServiceProvider serviceProvider, IMapper mapper)
        {
            _serviceProvider = serviceProvider;
            _mapper = mapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (await _timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                _timer = new(TimeSpan.FromHours(1));
                var movies = await GetTrendingMovies();

                if(movies.Results.Count() > 0)
                {
                    using (IServiceScope scope = _serviceProvider.CreateScope())
                    {
                        var service = scope.ServiceProvider.GetRequiredService<IRequestClient<AddMovies>>();
                        var response = await service.GetResponse<AddMoviesResult>(new AddMovies { Data = JsonSerializer.Serialize(movies.Results) });
                        if (response.Message.Status)
                        {
                            page++;
                        }
                    }
                }               
            }
        }

        private async Task<PaginationResponse<MovieDto>> GetTrendingMovies()
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetRequiredService<IMovieManager>();
                var result = await service.GetPopularMoviesFromTMBD(page);

                return result;
            }
        }

        //private async Task<bool> AddRangeAsync(List<MovieModel> models)
        //{
        //    using (IServiceScope scope = _serviceProvider.CreateScope())
        //    {
        //        var service = scope.ServiceProvider.GetRequiredService<IMovieManager>();
        //        var result = await service.AddRangeAsync(models);
        //        return result;
        //    }
        //}
    }
}
