CREATE PROCEDURE [dbo].[GetArtistDetails]
	@ArtistID INT

AS 
BEGIN

	SELECT artistID, title, biography, imageURL, heroURL FROM Artist (NOLOCK) 
	WHERE artistID = @ArtistID

	SELECT albumID, title, imageURL, year FROM Album WHERE artistID = @ArtistID

	SELECT songID, sg.title, alb.title as albumTitle, customMix, chart, rehearsalMix from Song sg
	INNER JOIN Album alb ON sg.albumID = alb.albumID WHERE sg.artistID = @ArtistID;

END