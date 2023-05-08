using DataAccess;
using Microsoft.Extensions.Configuration;
using MTModels.DTOs;
using MTModels.Entities;
using MTServices.BL.Interfaces;
using System.Data;

namespace MTServices.BL.Implementations
{
    public class Artists : IArtists
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        private SQL _sql;
        public Artists(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["admin"] ?? throw new Exception("connection string not provided");
            _sql = new SQL(_connectionString, true);
        }

        public Response<GetArtistDto> GetArtistByName(SearchArtists artists)
        {

            try
            {
                _sql.Parameters.Add("@searchTerm", artists.Name.Trim());
                using var reader = _sql.ExecuteStoredProcedureDataReader("GetArtistsByName");

                var response = new GetArtistDto();

                while (reader.Read())
                {
                    response.Artists.Add(new Artist
                    {
                        ArtistID = reader.GetInt32("artistID"),
                        Title = reader.GetString("title"),
                        Bography = reader.GetString("biography"),
                        ImageURL = reader.GetString("imageURL"),
                        HeroURL = reader.GetString("heroURL"),
                        DateCreation = reader.GetDateTime("dateCreation")
                    });
                }

                if (!response.Artists.Any())
                {
                    return new Response<GetArtistDto>(true, "No record found for this input", System.Net.HttpStatusCode.OK);
                }

                return new Response<GetArtistDto>(true, "operation successful", response, System.Net.HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return new Response<GetArtistDto>(false, ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }

        }

        public Response<CreateArtistResponse> CreateArtist(CreateArtist model)
        {
            try
            {
                _sql.Parameters.Add("@Title", model.Title);
                _sql.Parameters.Add("@Bography", model.Bography);
                _sql.Parameters.Add("@ImageURL", model.ImageURL);
                _sql.Parameters.Add("@HeroUrl", model.HeroURL);
                _sql.Parameters.Add("@DateCreation", DateTime.Now);

                var artistID = _sql.ExecuteStoredProcedureScalar<decimal>("CreateArtist");

                var response = new CreateArtistResponse { ArtistID = artistID };

                return new Response<CreateArtistResponse>(true, "operation successful", response, System.Net.HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return new Response<CreateArtistResponse>(false, ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }

        }
    }
}
