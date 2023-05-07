using MTModels.DTOs;
using MTModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTServices.BL.Interfaces
{
    public interface IArtists
    {
        Response<GetArtistDto> GetArtistByName(string name);

        Response<CreateArtistResponse> CreateArtist(CreateArtist model);

    }
}
