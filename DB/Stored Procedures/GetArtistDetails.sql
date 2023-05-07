CREATE PROCEDURE [dbo].[GetArtistDetails]
	@ArtistID INT

AS 
BEGIN

	SELECT artistID, title, biography, imageURL, heroURL FROM Artist (NOLOCK) 
	WHERE artistID = @ArtistID

	SELECT albumID, alb.title, alb.imageURL, art.title as artistTitle FROM Album alb (NOLOCK)
	INNER JOIN Artist art ON alb.artistID = art.artistID
	WHERE alb.artistID = @ArtistID

	SELECT songID, sg.title, alb.title as albumTitle, art.title as artistTitle, alb.imageURL as albumImage, chart, rehearsalMix, bpm from Song sg
	(NOLOCK)
	INNER JOIN Album alb ON sg.albumID = alb.albumID
	INNER JOIN Artist art ON sg.artistID = art.artistID
	WHERE sg.artistID = @ArtistID
END