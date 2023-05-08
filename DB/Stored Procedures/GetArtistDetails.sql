CREATE PROCEDURE dbo.GetArtistDetails
	@artistID INT

AS 
BEGIN
	SET NOCOUNT ON;

	SELECT 
		artistID, 
		title, 
		biography, 
		imageURL, 
		heroURL
	FROM Artist
	WHERE artistID = @artistID

	SELECT 
		a.albumID, 
		a.title, 
		a.imageURL, 
		ar.title AS artistTitle 
	FROM Album a
	INNER JOIN  Artist ar ON a.artistID = ar.artistID
	WHERE a.artistID = @artistID

	SELECT 
		s.songID, 
		s.title, 
		a.title AS albumTitle, 
		ar.title AS artistTitle, 
		a.imageURL AS albumImage,
		s.bpm 
	FROM Song s
	INNER JOIN Artist ar ON s.artistID = ar.artistID
	INNER JOIN Album a ON s.albumID = a.albumID
	WHERE s.artistID = @artistID

END