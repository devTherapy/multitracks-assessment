using MTModels.DTOs;

namespace MTServices.BL.Interfaces
{
    public interface IArtists
    {
        Response<GetArtistDto> GetArtistByName(SearchArtists artists);

        Response<CreateArtistResponse> CreateArtist(CreateArtist model);

    }
}
