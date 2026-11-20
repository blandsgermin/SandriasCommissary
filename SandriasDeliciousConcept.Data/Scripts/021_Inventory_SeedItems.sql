INSERT INTO dbo.Items (ItemName, Unit)
SELECT v.ItemName, v.Unit
FROM (VALUES
 -- Meat and poultry
 (N'Pork belly (liempo)', N'kg'), (N'Pork kasim', N'kg'), (N'Pork pigue', N'kg'),
 (N'Pork ribs', N'kg'), (N'Ground pork', N'kg'),
 (N'Beef chuck', N'kg'), (N'Beef brisket', N'kg'), (N'Beef shank', N'kg'), (N'Ground beef', N'kg'),
 (N'Whole dressed chicken', N'kg'), (N'Chicken breast fillet', N'kg'), (N'Chicken thigh', N'kg'),
 (N'Chicken wings', N'kg'), (N'Chicken drumstick', N'kg'), (N'Hotdog', N'kg'),
 -- Seafood
 (N'Bangus (milkfish)', N'kg'), (N'Tilapia', N'kg'), (N'Fish fillet (cream dory)', N'kg'),
 (N'Shrimp', N'kg'), (N'Squid', N'kg'),
 -- Vegetables and fruit
 (N'Cabbage', N'kg'), (N'Carrots', N'kg'), (N'Potatoes', N'kg'), (N'Chayote (sayote)', N'kg'),
 (N'Green beans (sitao)', N'kg'), (N'Baguio beans', N'kg'), (N'Red bell pepper', N'kg'),
 (N'Green bell pepper', N'kg'), (N'Broccoli', N'kg'), (N'Cauliflower', N'kg'),
 (N'Snow peas', N'kg'), (N'Pechay', N'kg'), (N'Eggplant', N'kg'), (N'Squash (kalabasa)', N'kg'),
 (N'Tomatoes', N'kg'), (N'Cucumber', N'kg'), (N'Lettuce', N'kg'),
 (N'Button mushroom', N'can'), (N'Green peas', N'can'), (N'Pineapple tidbits', N'can'),
 (N'Calamansi', N'kg'), (N'Lemon', N'kg'),
 -- Aromatics and spices
 (N'Red onion', N'kg'), (N'White onion', N'kg'), (N'Garlic', N'kg'), (N'Ginger', N'kg'),
 (N'Spring onion', N'kg'), (N'Siling labuyo', N'kg'), (N'Bay leaves', N'pack'), (N'Black pepper', N'pack'),
 -- Rice, noodles, pasta
 (N'Pancit canton', N'kg'), (N'Pancit bihon', N'kg'), (N'Sotanghon', N'kg'),
 (N'Macaroni (elbow)', N'kg'), (N'Spaghetti noodles', N'kg'),
 -- Condiments and pantry
 (N'Soy sauce', N'L'), (N'Vinegar', N'L'), (N'Oyster sauce', N'L'), (N'Fish sauce', N'L'),
 (N'Tomato sauce', N'pack'), (N'Tomato paste', N'can'), (N'Banana ketchup', N'bottle'),
 (N'Mayonnaise', N'L'), (N'Liver spread', N'can'), (N'Peanut butter', N'jar'),
 (N'Bagoong (shrimp paste)', N'jar'), (N'Gravy mix', N'pack'), (N'Seasoning granules', N'pack'),
 (N'Salt', N'kg'), (N'Sugar', N'kg'), (N'Brown sugar', N'kg'), (N'Cornstarch', N'kg'),
 (N'All-purpose flour', N'kg'), (N'Breadcrumbs', N'kg'),
 -- Dairy and eggs
 (N'Eggs', N'tray'), (N'All-purpose cream', N'pack'), (N'Evaporated milk', N'can'),
 (N'Cheese', N'kg'), (N'Butter', N'kg'), (N'Margarine', N'kg'),
 -- Drinks
 (N'Juice drink', N'pcs'), (N'Iced tea powder', N'pack'), (N'Soft drink (can)', N'pcs'),
 -- Packaging and supplies
 (N'Meal box (packed meal)', N'pcs'), (N'Food container with lid', N'pcs'),
 (N'Plastic spoon and fork', N'pack'), (N'Paper napkin', N'pack'), (N'Plastic cup', N'pcs'),
 (N'Aluminum foil', N'roll'), (N'Cling wrap', N'roll'), (N'Food tray (catering)', N'pcs'),
 (N'Disposable gloves', N'box'), (N'Paper bag', N'pcs')
) AS v(ItemName, Unit)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Items i WHERE i.ItemName = v.ItemName);
GO