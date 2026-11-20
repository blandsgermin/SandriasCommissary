CREATE OR ALTER PROCEDURE dbo.usp_Item_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ItemId, ItemName, Unit FROM dbo.Items ORDER BY ItemName;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_Item_Add @ItemName NVARCHAR(100), @Unit NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Name NVARCHAR(100) = LTRIM(RTRIM(@ItemName));
    IF @Name = N'' THROW 50010, 'Item name is required.', 1;
    IF NOT EXISTS (SELECT 1 FROM dbo.Items WHERE ItemName = @Name)
        INSERT INTO dbo.Items (ItemName, Unit) VALUES (@Name, @Unit);
    SELECT ItemId, ItemName, Unit FROM dbo.Items WHERE ItemName = @Name;
END
GO