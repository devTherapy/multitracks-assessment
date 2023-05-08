CREATE PROCEDURE dbo.GetArtistsByName
    @searchTerm NVARCHAR(100)
	
AS
BEGIN
    SET NOCOUNT ON 

    SELECT 
        artistID,
        heroURL, 
        imageURL, 
        biography,
        title, 
        dateCreation
    FROM Artist
    WHERE title LIKE '%' + @searchTerm + '%'

END
