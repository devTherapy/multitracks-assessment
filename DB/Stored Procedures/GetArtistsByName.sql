CREATE PROCEDURE [dbo].[GetArtistsByName]
	 @SearchTerm NVARCHAR(100)
	
AS
BEGIN

    SELECT *
    FROM Artist
    WHERE title LIKE '%' + @SearchTerm + '%'

END
