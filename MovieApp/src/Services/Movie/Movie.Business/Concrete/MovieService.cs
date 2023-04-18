using AutoMapper;
using Movie.Business.Abstract;
using Movie.Business.Utilities;
using Movie.DataAccess.Abstract;
using Movie.Entities.Common;
using Movie.Entities.Dto;
using Movie.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Movie.Business.Concrete
{
    public class MovieManager : IMovieManager
    {
        private readonly IMovieDAL _movieDAL;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IEmailHelper _emailHelper;

        public MovieManager(IMovieDAL movieDAL, HttpClient httpClient, IMapper mapper, IEmailHelper emailHelper)
        {
            _movieDAL = movieDAL;
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJkZTVkYmU3Nzk1YjM4NzhiNTRjZDlhY2QyNDBhY2ExMCIsInN1YiI6IjY0Mzk4NmM0NzY0NmZkMDA3NjIwYzg3MyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.fa3HXVQnQaRQh-GkJ-Mr40pIal3T6zORhquqxC2SJrE");
            _mapper = mapper;
            _emailHelper = emailHelper;
        }

        public async Task<MovieModel> AddAsync(MovieModel movie)
        {
            var result = await _movieDAL.AddAsync(movie);
            return result;
        }

        public async Task<bool> AddRangeAsync(List<MovieModel> movies)
        {
            var result = await _movieDAL.AddRangeAsync(movies);

            return result;
        }

        public async Task<string> AdviceMovie(int movieId, string email)
        {
            var movie = await GetByIdAsync(movieId);
            if (movie == null)
                return "The movie cannot found!";

            var emailResult = await _emailHelper.SendEmailAsync();

            if(emailResult)
            {
                return $"Sent '{movie.Title}' to {email}";
            }

            return null;
        }

        public async Task<PaginationResponse<MovieModel>> GetAllMovieAsync(PaginationRequest pagination)
        {
            var results = await _movieDAL.GetAllPaginationAsync(pagination);
            return results;
        }

        public async Task<MovieModel> GetByIdAsync(long id)
        {
            var result = await _movieDAL.GetAsync(x => x.Id == id);
            return result;
        }
        
        public async Task<MovieDto> GetLastMovieFromTMBD()
        {
            var request = await _httpClient.GetAsync("https://api.themoviedb.org/3/movie/latest?api_key=de5dbe7795b3878b54cd9acd240aca10&language=en-US");
            if (request.IsSuccessStatusCode)
            {
                var result = await request.Content.ReadFromJsonAsync<MovieDto>();
                return result;
            }

            return null;
        }

        public async Task<PaginationResponse<MovieDto>> GetPopularMoviesFromTMBD(int page)
        {
            var request = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/popular?api_key=de5dbe7795b3878b54cd9acd240aca10&language=en-US&page={page}");
            if (request.IsSuccessStatusCode)
            {
                var result = await request.Content.ReadFromJsonAsync<PaginationResponse<MovieDto>>();
                return result;
            }

            return null;
        }

        public async Task<MovieModel> UpdateAsync(MovieUpdateDto movie, int id)
        {
            var exist = await GetByIdAsync(id);
            if (exist != null && movie.Id == id)
            {
                var update = _mapper.Map(movie, exist);
                var result = await _movieDAL.UpdateAsync(update);
                return result;
            }

            return null;
        }
    }
}
