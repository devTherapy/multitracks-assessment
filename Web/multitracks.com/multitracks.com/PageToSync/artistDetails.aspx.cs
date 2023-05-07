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
             sql.Parameters.Add("@ArtistID", 172);
            var dataset = sql.ExecuteStoredProcedureDS("GetArtistDetails");


            SetTables(dataset);
            //assessmentItems.DataSource = data;
            //assessmentItems.DataBind();
            // publishDB.Visible = false;
            //items.Visible = true;
        }
        catch
        {
            //publishDB.Visible = true;
            //items.Visible = false;
        }
    }

    private void SetTables(DataSet dataSet)
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

        //set other data

        bannerImage.ImageUrl = artistTable.Rows[0]["imageURL"].ToString();
        heroImage.ImageUrl = artistTable.Rows[0]["heroURL"].ToString();
        Bio.Text = artistTable.Rows[0]["biography"].ToString();
    }
}
