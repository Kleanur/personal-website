DECLARE @pCategoryID int = 0
SET @pCategoryID = (SELECT @pCategoryID)

EXEC [dbo].[Blogs] @pCategoryID

/*
DECLARE @BlogID int
DECLARE @Categories nvarchar(MAX)

IF OBJECT_ID('tempdb..#return') IS NOT NULL DROP TABLE #return
CREATE TABLE #return (
	BlogID int,
	BlogTitle nvarchar(MAX),
	BlogDate date,
	Categories nvarchar(MAX)
	)

INSERT INTO #return (BlogID, BlogTitle, BlogDate)
SELECT DISTINCT B.BlogID, B.BlogTitle, B.BlogDate
FROM Blog B INNER JOIN BlogCategoryBlog BCB
ON B.BlogID = BCB.BlogID 
WHERE BCB.BlogCategoryID = @pCategoryID OR @pCategoryID = 0

DECLARE db_cursor CURSOR FOR
SELECT BlogID
FROM #return

OPEN db_cursor

FETCH NEXT FROM db_cursor INTO @BlogID

WHILE @@FETCH_STATUS = 0  
 
BEGIN  
	SET @Categories = ''
	SELECT @Categories = @Categories + CASE WHEN @Categories = '' THEN '' ELSE ', ' END + BC.CategoryName
	FROM BlogCategoryBlog BCB INNER JOIN BlogCategory BC
	ON BCB.BlogCategoryID = BC.BlogCategoryID
	WHERE BCB.BlogID = @BlogID

	UPDATE #return
	SET Categories = @Categories
	WHERE BlogID = @BlogID --AND EXISTS (SELECT 1 FROM BlogCategoryBlog WHERE BlogID = @BlogID AND BlogCategoryID = @pCategoryID)

 	FETCH NEXT FROM db_cursor INTO @BlogID
END 

CLOSE db_cursor

DEALLOCATE db_cursor

--DELETE FROM #return WHERE Categories IS NULL

SELECT * FROM #return ORDER BY BlogDate DESC
*/