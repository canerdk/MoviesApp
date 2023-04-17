using AutoMapper;
using Movie.Entities.Dto;
using Movie.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Business.EntityProfile
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDto, MovieModel>().ReverseMap();
            //CreateMap<MovieDto,MovieModel>();
        }
    }
}
