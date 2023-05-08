using DataAccess;
using Microsoft.Extensions.Configuration;
using MTModels.DTOs;
using MTModels.Entities;
using MTServices.BL.Interfaces;
using System.Text;
using System.Data;

namespace MTServices.BL.Implementations
{
    public class Songs : ISongs
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        private SQL _sql;
        public Songs(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["admin"] ?? throw new Exception("connection string not provided");
            _sql = new SQL(_connectionString, true);
        }
        public Response<SongDto> GetSongs(Paging paging)
        {
            var pageSize = paging.PageSize <= 0 ? 10 : paging.PageSize;
            var pageNumber = paging.PageNumber <= 0 ? 1 : paging.PageNumber;

            try
            {
                _sql = new SQL(_connectionString, true);
                _sql.Parameters.Add("@PageSize", pageSize);
                _sql.Parameters.Add("@PageNumber", pageNumber);
                using var reader = _sql.ExecuteStoredProcedureDataReader("GetSongs");

                var response = new SongDto();
                while (reader.Read())
                {
                    response.SongsList.Add(new Song
                    {
                        SongID = reader.GetInt32("songID"),
                        AlbumID = reader.GetInt32("albumID"),
                        ArtistID = reader.GetInt32("artistID"),
                        Title = reader.GetString("title"),
                        Bpm = reader.GetDecimal("bpm"),
                        TimeSignature = reader.GetString("timeSignature"),
                        Multitracks = reader.GetBoolean("multitracks"),
                        CustomMix = reader.GetBoolean("customMix"),
                        Chart = reader.GetBoolean("chart"),
                        RehearsalMix = reader.GetBoolean("rehearsalMix"),
                        Patches = reader.GetBoolean("patches"),
                        SongSpecificPatches = reader.GetBoolean("songSpecificPatches"),
                        ProPresenter = reader.GetBoolean("propresenter"),
                        DateCreation = reader.GetDateTime("dateCreation")
                    });
                }

                if (reader.NextResult())
                {
                    reader.Read();
                    var totalRecords = reader.GetInt32("TotalCount");

                    response.MetaData  = new Metadata
                    {
                        PageSize = pageSize,
                        PageNumer = pageNumber,
                        TotalRecords = reader.GetInt32("TotalCount"),
                        TotalPages = totalRecords <= 0 ? 0 : totalRecords / pageSize
                    };
                }

                if (!response.SongsList.Any())
                {
                    return new Response<SongDto>(true, "No record found for this input", System.Net.HttpStatusCode.OK);
                }
                return new Response<SongDto>(true, "operation successful", response, System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new Response<SongDto>(false, ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }

        }
    }
}
