IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
CREATE TABLE dbo.Users (
    UserId   INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50)  NOT NULL UNIQUE,
    FullName NVARCHAR(100) NOT NULL,
    Role     NVARCHAR(30)  NOT NULL   -- Chef, Owner, InventoryClerk, Purchaser
);
GO
IF OBJECT_ID(N'dbo.Items', N'U') IS NULL
CREATE TABLE dbo.Items (
    ItemId   INT IDENTITY(1,1) PRIMARY KEY,
    ItemName NVARCHAR(100) NOT NULL UNIQUE,
    Unit     NVARCHAR(20)  NOT NULL
);
GO
IF OBJECT_ID(N'dbo.RF', N'U') IS NULL
CREATE TABLE dbo.RF (
    RfId         INT IDENTITY(1,1) PRIMARY KEY,
    RfNumber     NVARCHAR(30)  NOT NULL UNIQUE,
    RequestDate  DATETIME2     NOT NULL DEFAULT SYSDATETIME(),
    Requester    NVARCHAR(100) NOT NULL,
    CustomerName NVARCHAR(100) NULL,
    EventDate    DATE          NULL,
    Venue        NVARCHAR(150) NULL,
    Pax          INT           NULL,
    Menu         NVARCHAR(100) NULL,
    Purpose      NVARCHAR(200) NOT NULL,
    RequiredDate DATE          NULL,
    Status       NVARCHAR(30)  NOT NULL DEFAULT N'Pending',
    ApprovedBy   NVARCHAR(100) NULL,
    ApprovedDate DATETIME2     NULL,
    Remarks      NVARCHAR(300) NULL
);
GO
IF OBJECT_ID(N'dbo.RFItem', N'U') IS NULL
CREATE TABLE dbo.RFItem (
    RfItemId INT IDENTITY(1,1) PRIMARY KEY,
    RfId     INT NOT NULL REFERENCES dbo.RF(RfId) ON DELETE CASCADE,
    ItemId   INT NOT NULL,
    ItemName NVARCHAR(100) NOT NULL,
    Unit     NVARCHAR(20)  NOT NULL,
    Quantity DECIMAL(10,2) NOT NULL CHECK (Quantity > 0)
);
GO