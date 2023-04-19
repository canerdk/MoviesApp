using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Business.Abstract;
using Movie.Entities.Common;
using Movie.Entities.Dto;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieManager _movieManager;

        public MoviesController(IMovieManager movieManager)
        {
            _movieManager = movieManager;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _movieManager.GetByIdAsync(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
        {
            var validFilter = new PaginationRequest(pageIndex, pageSize);
            var results = await _movieManager.GetAllMovieAsync(validFilter);
            return Ok(results);
        }

        [HttpPost("advice")]
        public async Task<IActionResult> Advice(int movieId, string email)
        {
            var result = await _movieManager.AdviceMovie(movieId, email);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(MovieUpdateDto movie, int id)
        {
            var result = await _movieManager.UpdateAsync(movie, id);
            return Ok(result);
        }
    }
}
