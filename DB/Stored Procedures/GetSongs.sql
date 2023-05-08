CREATE PROCEDURE GetSongs
	@PageSize INT,
	@PageNumber INT

AS
BEGIN

	SET NOCOUNT ON

	SELECT * 
	FROM Song
	ORDER BY dateCreation DESC
	OFFSET (@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY

	SELECT COUNT(*) AS TotalCount FROM Song

END

