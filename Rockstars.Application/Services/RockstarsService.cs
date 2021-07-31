using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rockstars.Application.Interfaces;
using Rockstars.Domain.DTOs;
using Rockstars.Domain.Entities;
using Rockstars.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rockstars.Application.Services
{
    public class RockstarsService : IRockstarsService
    {
        private readonly IRepository<Artist> _artistRepository;
        private readonly IRepository<Song> _songRepository;
        private readonly IMapper _mapper;
        public RockstarsService(IRepository<Artist> artistRepository,
                                IRepository<Song> songRepository,
                                IMapper mapper)
        {
            _artistRepository = artistRepository ?? throw new ArgumentNullException(nameof(artistRepository));
            _songRepository = songRepository ?? throw new ArgumentNullException(nameof(songRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //TODO: Add checks for duplicate inserts for better error handling.

        public void FilterAndInsert(IEnumerable<ArtistWriteDTO> artists, IEnumerable<SongWriteDTO> songs)
        {
            // 1. Filter songs
            var filteredSongs = songs.Where(SongFilter);

            // 2. Group artist with corresponding songs
            var artistsWithSongsWrapper = new List<ArtistWithSongsWrapper>();

            foreach (var artist in artists)
            {
                var matchedSongs = filteredSongs.Where(x => x.Artist.Equals(artist.Name, StringComparison.OrdinalIgnoreCase));

                if (matchedSongs?.Any() is true)
                {
                    artistsWithSongsWrapper.Add(new ArtistWithSongsWrapper
                    {
                        ArtistWriteDTO = artist,
                        SongWriteDTOs = matchedSongs
                    });
                }
            }

            // 3. Map song to artist
            var mappedArtistsWithSongs = _mapper.Map<List<Artist>>(artistsWithSongsWrapper);

            // 4. Save artist with corresponding songs in database
            _artistRepository.InsertMany(mappedArtistsWithSongs);
            _artistRepository.SaveChanges();
        }

        public void FilterAndInsert(IEnumerable<SongWriteDTO> songs)
        {
            // 1. Filter songs
            var filteredAndGroupedSongsByArtist = songs.Where(SongFilter).GroupBy(x => x.Artist);

            // 2. Get artist for songs
            var SongsWithArtistIdWrapper = new List<SongWithArtistIdWrapper>();
            foreach (var groupedSongs in filteredAndGroupedSongsByArtist)
            {
                var artist = _artistRepository.Find(x => x.Name == groupedSongs.Key);

                if(artist == null)
                {
                    continue;
                    //throw new Exception($"Artist {groupedSongs.Key} was not found.");
                }

                foreach(var song in groupedSongs)
                {
                    SongsWithArtistIdWrapper.Add(
                        new SongWithArtistIdWrapper
                        {
                            SongWriteDTO = song,
                            ArtistId = artist.Id
                        }
                    );
                }
            }

            // 3. Map songs
            var mappedSongs = _mapper.Map<List<Song>>(SongsWithArtistIdWrapper);

            // 4. Save songs
            _songRepository.InsertMany(mappedSongs);
            _artistRepository.SaveChanges();
        }


        public ArtistReadDTO FindArtistByName(string name)
        {
            var artist = _artistRepository.Find(x => x.Name.Contains(name),
                                                y => y.Include(a => a.Songs));

           return _mapper.Map<ArtistReadDTO>(artist);
        }

        private Func<SongWriteDTO, bool> SongFilter 
            => new Func<SongWriteDTO, bool>(x => x.Year < 2016 && x.Genre.Contains("Metal"));
    }
}
