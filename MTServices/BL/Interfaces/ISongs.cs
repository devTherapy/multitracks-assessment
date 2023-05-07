using MTModels.DTOs;
using MTModels.Entities;

namespace MTServices.BL.Interfaces
{
    public interface ISongs
    {
        Response<SongDto> GetSongs(Paging paging);

    };
}
