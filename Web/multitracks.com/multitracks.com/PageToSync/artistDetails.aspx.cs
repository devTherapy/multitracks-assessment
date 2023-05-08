using DataAccess;
using System;
using System.Data;

public partial class Default : MultitracksPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();
        try
        {
            //5
            //31
            //1321
          //  throw new NotImplementedException();
             sql.Parameters.Add("@ArtistID", 1110);
            var dataset = sql.ExecuteStoredProcedureDS("GetArtistDetails");
            BindData(dataset);


            SetTables(dataset);
            //assessmentItems.DataSource = data;
            //assessmentItems.DataBind();
            // publishDB.Visible = false;
            //items.Visible = true;
        }
        catch
        {

        }
    }

    private void BindData(DataSet dataSet)
    {
        var artistTable = dataSet.Tables[0];
        var albumTable = dataSet.Tables[1];
        var songTable = dataSet.Tables[2];

        //artistName = artistTable.Rows[0]["Title"].ToString();
        //albumName = albumTable.Rows[0]["Title"].ToString();

        //prepare album data
        //albumTable.Columns.Add("ArtistName", typeof(string));

        //albumTable.Rows[0]["ArtistName"] = artistName;

        AlbumList.DataSource = albumTable;

        AlbumList.DataBind();

        //prepare song data
        //songTable.Columns.Add("AlbumName", typeof(string));

        //songTable.Rows[0]["AlbumName"] = albumName;

        SongsList.DataSource = songTable;

        SongsList.DataBind();

        heroImage.ImageUrl = artistTable.Rows[0]["heroURL"].ToString();
        heroImage.Attributes["srcset"] = $"{artistTable.Rows[0]["heroURL"]}, {artistTable.Rows[0]["heroURL"]} 2x";
        bannerImage.ImageUrl = artistTable.Rows[0]["imageURL"].ToString();
        bannerImage.Attributes["srcset"] = $"{artistTable.Rows[0]["imageURL"]}, {artistTable.Rows[0]["imageURL"]} 2x";
        BannerName.Text = artistTable.Rows[0]["title"].ToString(); 
        Bio.Text = artistTable.Rows[0]["biography"].ToString();
    }
}
