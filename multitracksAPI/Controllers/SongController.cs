using Microsoft.AspNetCore.Mvc;
using MTModels.DTOs;
using MTServices.BL.Interfaces;

namespace multitracksAPI.Controllers
{
    [ApiController]
    [Route("api.multitracks.com/song")]
    public class SongController : ControllerBase
    {
        private readonly ISongs _songs;

        public SongController(ISongs songs)
        {
            _songs = songs;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllSongs([FromQuery] Paging paging)
        {
            var result = _songs.GetSongs(paging);
            return StatusCode((int)result.Status, result);
        }
    }
}
