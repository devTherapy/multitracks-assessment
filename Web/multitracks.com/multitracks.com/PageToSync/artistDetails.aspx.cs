using DataAccess;
using System;
using System.Data;
using System.Diagnostics;

public partial class ArtistDetails : MultitracksPage
{
    public ArtistDetails()
    {
        Load += Page_Load;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var sql = new SQL();
            sql.Parameters.Add("@artistID", Request.QueryString["ID"] ?? "52");
            var dataset = sql.ExecuteStoredProcedureDS("GetArtistDetails");
            BindData(dataset);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

    }

    private void BindData(DataSet dataSet)
    {
        var artists = dataSet.Tables[0];
        var albums = dataSet.Tables[1];
        var songs = dataSet.Tables[2];

        AlbumList.DataSource = albums;
        AlbumList.DataBind();

        SongsList.DataSource = songs;
        SongsList.DataBind();

        heroImage.ImageUrl = artists.Rows[0]["heroURL"].ToString();
        heroImage.Attributes["srcset"] = $"{artists.Rows[0]["heroURL"]}, {artists.Rows[0]["heroURL"]} 2x";
        bannerImage.ImageUrl = artists.Rows[0]["imageURL"].ToString();
        bannerImage.Attributes["srcset"] = $"{artists.Rows[0]["imageURL"]}, {artists.Rows[0]["imageURL"]} 2x";
        BannerName.Text = artists.Rows[0]["title"].ToString(); 
        Bio.Text = artists.Rows[0]["biography"].ToString();
    }
}