INSERT INTO dbo.Dishes (DishName, Category)
SELECT v.DishName, v.Category
FROM (VALUES
 (N'Chicken Cordon Bleu', N'Chicken'), (N'Garlic Butter Fried Chicken', N'Chicken'),
 (N'Chicken Teriyaki', N'Chicken'), (N'Spicy Buffalo Wings', N'Chicken'),
 (N'Pork Humba', N'Pork'), (N'Lechon Kawali', N'Pork'),
 (N'Pork Sisig', N'Pork'), (N'Sweet and Sour Pork', N'Pork'),
 (N'Beef Caldereta', N'Beef'), (N'Roast Beef with Mushroom Sauce', N'Beef'),
 (N'Beef with Broccoli', N'Beef'), (N'Beef Kare-Kare', N'Beef'),
 (N'Chopsuey', N'Vegetables'), (N'Buttered Mixed Vegetables', N'Vegetables'),
 (N'Four Seasons Vegetables', N'Vegetables'), (N'Pinakbet', N'Vegetables'),
 (N'Pancit Canton', N'Pancit / Noodles'), (N'Bam-i (Canton & Sotanghon Mix)', N'Pancit / Noodles'),
 (N'Sotanghon Guisado', N'Pancit / Noodles'), (N'Baked Macaroni', N'Pancit / Noodles')
) AS v(DishName, Category)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Dishes d WHERE d.DishName = v.DishName);
GO