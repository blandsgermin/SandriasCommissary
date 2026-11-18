IF COL_LENGTH('dbo.Users', 'PasswordSalt') IS NULL
    ALTER TABLE dbo.Users ADD PasswordSalt VARBINARY(16) NULL;
GO
IF COL_LENGTH('dbo.Users', 'PasswordHash') IS NULL
    ALTER TABLE dbo.Users ADD PasswordHash VARBINARY(32) NULL;
GO
UPDATE dbo.Users SET PasswordSalt = CRYPT_GEN_RANDOM(16) WHERE PasswordHash IS NULL;
GO
-- Demo passwords: username + 123 (for example chef123). Change them for real use.
UPDATE dbo.Users
SET PasswordHash = HASHBYTES('SHA2_256', PasswordSalt + CAST(Username + N'123' AS VARBINARY(200)))
WHERE PasswordHash IS NULL;
GO
CREATE OR ALTER PROCEDURE dbo.usp_User_Login @Username NVARCHAR(50), @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT UserId, Username, FullName, Role
    FROM dbo.Users
    WHERE Username = @Username
      AND PasswordHash = HASHBYTES('SHA2_256', PasswordSalt + CAST(@Password AS VARBINARY(200)));
END
GO