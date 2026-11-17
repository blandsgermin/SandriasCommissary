IF NOT EXISTS (SELECT 1 FROM dbo.Users)
INSERT INTO dbo.Users (Username, FullName, Role) VALUES
 (N'chef', N'Chef', N'Chef'),
 (N'owner', N'Owner', N'Owner'),
 (N'clerk', N'Inventory Clerk', N'InventoryClerk'),
 (N'purchaser', N'Purchaser', N'Purchaser');
GO
IF NOT EXISTS (SELECT 1 FROM dbo.Items)
INSERT INTO dbo.Items (ItemName, Unit) VALUES
 (N'Pork', N'kg'), (N'Beef', N'kg'), (N'Chicken', N'kg'),
 (N'Pancit noodles', N'kg'), (N'Vegetables', N'kg'), (N'Rice', N'kg'),
 (N'Cooking oil', N'L'), (N'Bottled water', N'pcs');
GO