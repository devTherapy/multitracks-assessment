CREATE PROCEDURE GetSongs
	@PageSize INT = 10,
	@PageNumber INT = 1

AS
BEGIN



	SELECT * FROM Song (NOLOCk)
	ORDER BY dateCreation DESC
	OFFSET (@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY

	SELECT COUNT(*) AS TotalCount FROM Song (NOLOCK)
END

