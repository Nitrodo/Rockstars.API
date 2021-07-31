using AutoMapper;
using Rockstars.Domain.DTOs;
using Rockstars.Domain.Entities;
using Rockstars.Domain.Models;

namespace Rockstars.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Artist, ArtistReadDTO>();
            CreateMap<ArtistWriteDTO, Artist>()
                .ForMember(x => x.Songs, opts => opts.Ignore());

            CreateMap<Song, SongReadDTO>();
            CreateMap<SongWriteDTO, Song>()
                .ForMember(x => x.ArtistId, opt => opt.Ignore());

            CreateMap<ArtistWithSongsWrapper, Artist>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.ArtistWriteDTO.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.ArtistWriteDTO.Name))
                .ForMember(x => x.Songs, opt => opt.MapFrom(x => x.SongWriteDTOs));

            CreateMap<SongWithArtistIdWrapper, Song>()
                .ForMember(x => x.Album, opt => opt.MapFrom(x => x.SongWriteDTO.Album))
                .ForMember(x => x.Bpm, opt => opt.MapFrom(x => x.SongWriteDTO.Bpm))
                .ForMember(x => x.Duration, opt => opt.MapFrom(x => x.SongWriteDTO.Duration))
                .ForMember(x => x.Genre, opt => opt.MapFrom(x => x.SongWriteDTO.Genre))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.SongWriteDTO.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.SongWriteDTO.Name))
                .ForMember(x => x.Shortname, opt => opt.MapFrom(x => x.SongWriteDTO.Shortname))
                .ForMember(x => x.SpotifyId, opt => opt.MapFrom(x => x.SongWriteDTO.SpotifyId))
                .ForMember(x => x.Year, opt => opt.MapFrom(x => x.SongWriteDTO.Year));
        }
    }
}
