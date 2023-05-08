CREATE PROCEDURE dbo.CreateArtist
	@Title VARCHAR(100),
	@Bography VARCHAR(MAX),
	@ImageURL VARCHAR(500),
	@HeroUrl  VARCHAR(500),
	@DateCreation SMALLDATETIME

AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO Artist (title, biography, imageURL, heroURL, dateCreation)
	VALUES (@Title, @Bography, @ImageURL, @HeroUrl, @DateCreation);

	SELECT @@IDENTITY AS artistID
END
