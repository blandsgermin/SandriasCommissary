CREATE OR ALTER PROCEDURE dbo.usp_RF_Create
    @Requester NVARCHAR(100), @CustomerName NVARCHAR(100) = NULL, @EventDate DATE = NULL,
    @Venue NVARCHAR(150) = NULL, @Pax INT = NULL, @Menu NVARCHAR(100) = NULL,
    @Purpose NVARCHAR(200), @RequiredDate DATE = NULL, @NewRfId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.RF (RfNumber, Requester, CustomerName, EventDate, Venue, Pax, Menu, Purpose, RequiredDate)
    VALUES (LEFT(CAST(NEWID() AS NVARCHAR(36)), 30), @Requester, @CustomerName, @EventDate, @Venue, @Pax, @Menu, @Purpose, @RequiredDate);
    SET @NewRfId = SCOPE_IDENTITY();
    UPDATE dbo.RF
    SET RfNumber = N'RF-' + CAST(YEAR(SYSDATETIME()) AS NVARCHAR(4)) + N'-' + RIGHT(N'00000' + CAST(@NewRfId AS NVARCHAR(10)), 5)
    WHERE RfId = @NewRfId;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_RFItem_Add
    @RfId INT, @ItemId INT, @ItemName NVARCHAR(100), @Unit NVARCHAR(20), @Quantity DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.RFItem (RfId, ItemId, ItemName, Unit, Quantity)
    VALUES (@RfId, @ItemId, @ItemName, @Unit, @Quantity);
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_RF_GetAll @Status NVARCHAR(30) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.RF WHERE (@Status IS NULL OR Status = @Status) ORDER BY RfId DESC;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_RF_GetById @RfId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.RF WHERE RfId = @RfId;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_RFItem_GetByRf @RfId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM dbo.RFItem WHERE RfId = @RfId ORDER BY RfItemId;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_RF_Update
    @RfId INT, @CustomerName NVARCHAR(100) = NULL, @EventDate DATE = NULL, @Venue NVARCHAR(150) = NULL,
    @Pax INT = NULL, @Menu NVARCHAR(100) = NULL, @Purpose NVARCHAR(200), @RequiredDate DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.RF
    SET CustomerName = @CustomerName, EventDate = @EventDate, Venue = @Venue, Pax = @Pax,
        Menu = @Menu, Purpose = @Purpose, RequiredDate = @RequiredDate,
        Status = N'Pending', Remarks = NULL
    WHERE RfId = @RfId AND Status IN (N'Pending', N'Returned');
    IF @@ROWCOUNT = 0 THROW 50002, 'Only a pending or returned requisition can be edited.', 1;
    DELETE FROM dbo.RFItem WHERE RfId = @RfId;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_RF_Approve @RfId INT, @ApprovedBy NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.RF SET Status = N'Approved', ApprovedBy = @ApprovedBy, ApprovedDate = SYSDATETIME()
    WHERE RfId = @RfId AND Status = N'Pending';
    IF @@ROWCOUNT = 0 THROW 50003, 'Only a pending requisition can be approved.', 1;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_RF_Return @RfId INT, @Reason NVARCHAR(300)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.RF SET Status = N'Returned', Remarks = @Reason
    WHERE RfId = @RfId AND Status = N'Pending';
    IF @@ROWCOUNT = 0 THROW 50004, 'Only a pending requisition can be returned.', 1;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_RF_Cancel @RfId INT, @Reason NVARCHAR(300)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.RF SET Status = N'Cancelled', Remarks = @Reason
    WHERE RfId = @RfId AND Status IN (N'Pending', N'Returned');
    IF @@ROWCOUNT = 0 THROW 50005, 'Only a pending or returned requisition can be cancelled.', 1;
END
GO
CREATE OR ALTER PROCEDURE dbo.usp_RF_SetStatus @RfId INT, @Status NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    IF @Status NOT IN (N'Pending', N'Approved', N'Returned', N'Cancelled', N'PendingFulfillment', N'Fulfilled')
        THROW 50006, 'Invalid status.', 1;
    UPDATE dbo.RF SET Status = @Status WHERE RfId = @RfId;
    IF @@ROWCOUNT = 0 THROW 50007, 'Requisition not found.', 1;
END
GO