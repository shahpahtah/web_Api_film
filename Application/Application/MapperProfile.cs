using AutoMapper;
using Data;
using Film;
using Web.Models;

namespace Application
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Film.Film, FilmDb>().ReverseMap();
            CreateMap<FilmDb, FilmViewModel>().ReverseMap();
            CreateMap<CreateFilmViewModel, FilmDb>();
        }
    }
}
