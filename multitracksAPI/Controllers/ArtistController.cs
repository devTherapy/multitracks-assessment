using Microsoft.AspNetCore.Mvc;
using MTModels.DTOs;
using MTServices.BL.Interfaces;
using System.Net;

namespace multitracksAPI.Controllers
{
    [ApiController]
    [Route("api.multitracks.com/artist")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtists _artists;

        public ArtistController(IArtists artist)
        {
            _artists = artist;
        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchArtists([FromQuery] SearchArtists artist)
        {
            var result =  _artists.GetArtistByName(artist);
            return StatusCode((int)result.Status, result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateArtist(CreateArtist model)
        {
            var result = _artists.CreateArtist(model);
            return StatusCode((int)result.Status, result);
        }


    }
}
