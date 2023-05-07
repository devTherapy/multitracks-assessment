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
        public async Task<IActionResult> SearchArtists(string name)
        {
            var result =  _artists.GetArtistByName(name);

            if (result.Status == HttpStatusCode.OK) return Ok(result); 
            if (result.Status == HttpStatusCode.BadRequest) return BadRequest(result); 
            return StatusCode((int)result.Status, result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateArtist(CreateArtist model)
        {
            var result = _artists.CreateArtist(model);

            if (result.Status == HttpStatusCode.OK) return Ok(result);
            if (result.Status == HttpStatusCode.BadRequest) return BadRequest(result);
            return StatusCode((int)result.Status, result);
        }


    }
}
