CREATE OR ALTER PROCEDURE dbo.usp_Item_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ItemId, ItemName, Unit FROM dbo.Items ORDER BY ItemName;
END
GO