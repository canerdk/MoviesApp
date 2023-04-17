using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Business.Abstract;

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


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _movieManager.GetAllMovieAsync();
            return Ok(results);
        }
    }
}
