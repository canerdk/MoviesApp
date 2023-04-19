using EventBus.Events;
using MassTransit;
using Movie.Business.Abstract;
using Movie.Entities.Entities;
using System.Text.Json;

namespace Movie.Api.Consumers
{
    public class AddMovieConsumer : IConsumer<AddMovies>
    {
        private readonly IMovieManager _movieManager;
        private readonly ILogger<AddMovieConsumer> _logger;

        public AddMovieConsumer(IMovieManager movieManager, ILogger<AddMovieConsumer> logger)
        {
            _movieManager = movieManager;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<AddMovies> context)
        {
            var deserializeData = JsonSerializer.Deserialize<List<MovieModel>>(context.Message.Data);
            var result = await _movieManager.AddRangeAsync(deserializeData);
            if (!result)
                throw new InvalidOperationException("Movies cannot add");

            await context.RespondAsync<AddMoviesResult>(new
            {
               Status = result
            });
        }
    }
}
