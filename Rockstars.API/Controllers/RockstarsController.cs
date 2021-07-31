using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rockstars.Application.Helpers;
using Rockstars.Application.Interfaces;
using Rockstars.Domain.DTOs;
using System;

namespace Rockstars.API.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RockstarsController : ControllerBase
    {
        private readonly IRockstarsService _rockstarsService;
        public RockstarsController(IRockstarsService rockstarsService)
        {
            _rockstarsService = rockstarsService ?? throw new ArgumentNullException(nameof(rockstarsService));
        }

        /// <summary>
        /// Search artists by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Artist/Search/Name/{name}")]
        public ActionResult<ArtistReadDTO> SearchArtistsByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Name is required");
                }

                var artists = _rockstarsService.FindArtistByName(name);
                return Ok(artists);
            }
            catch (Exception e)
            {
                return BadRequest($"Exception message: {e.Message} Inner exception: {e.InnerException}");
            }
        }

        /// <summary>
        /// Upload files to import data
        /// </summary>
        /// <param name="artistsFile"></param>
        /// <param name="songsFile"></param>
        /// <returns></returns>
        [HttpPost("Upload")]
        public ActionResult Post(IFormFile artistsFile, IFormFile songsFile)
        {
            try
            {
                // The song file is mandetory.
                if (songsFile == null)
                {
                    return BadRequest("The songs file is required");
                }

                var songs = FileHelper.FileToObject<SongWriteDTO>(songsFile);

                if (!TryValidateModel(songs, nameof(SongWriteDTO)))
                {
                    return BadRequest(ModelState);
                }

                // The artist file is not mandetory. It's possible to add new songs for existing artists.
                if (artistsFile == null)
                {
                    _rockstarsService.FilterAndInsert(songs);
                }
                else
                {
                    var artists = FileHelper.FileToObject<ArtistWriteDTO>(artistsFile);

                    if (!TryValidateModel(artists, nameof(ArtistWriteDTO)))
                    {
                        return BadRequest(ModelState);
                    }

                    _rockstarsService.FilterAndInsert(artists, songs);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Exception message: {e.Message} Inner exception: {e.InnerException}");
            }
        }
    }
}
