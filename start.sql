USE mtaDB;

-- Insert all Permissions per default
INSERT INTO Permission
(PermissionName)
VALUES 
('menu invoice'),('menu purchaseorder'),('menu product'),('menu statistic'),('menu admin'),
('invoice delete'),('invoice insert'),('invoice register'),('invoice update'),('invoice view'),
('payment delete'),('payment insert'),('payment update'),('payment view'),
('purchaseorder delete'),('purchaseorder generate'),('purchaseorder insert'),('purchaseorder manage'),
('purchaseorder update'),('purchaseorder view'),
('product delete'),('product insert'),('product price update'),('product retail update'),('product search'),
('product update'),('product view'),('product wholesale update'),
('statistics graphs'),('statistics ranking'),
('perfil update'),('password update'),,
('user delete'),('user insert'),('user update'),('user view')
('role delete'),('role insert'),('role update'),('role view'),
('permission delete'),('permission insert'),('permission update'),('permission view'),
('brand delete'),('brand insert'),('brand update'),('brand view'),
('sector delete'),('sector insert'),('sector update'),('sector view'),
('supplier delete'),('supplier insert'),('supplier update'),('supplier view')

-- Inserts the Role named 'admin'
INSERT INTO Role
(RoleName)
VALUES
('admin')

-- Asign all Permission per default to Role 'admin'
DECLARE @i INT = 1;
WHILE @i <= 56 
	BEGIN 
		INSERT INTO RolePermission
			(RoleId, PermissionId)
			VALUES
			(1, @i); 
			
		SET @i = @i + 1; 
	END;
	
-- Inserts the user named 'admin' with Role 'admin' and all Permission per default
-- username='admin' password='admin'
INSERT INTO [dbo].[User]
(UserName, UserEmail, UserPassword, UserHash, UserCreatedDate, UserModifiedDate, RoleId, UserActive)
Values
('admin', NULL, '6TcrbW6aQLpn5eAdC2CGhw==', '00EE96214EC4EBD28D028C80B72EFA75', GETDATE(), NULL, 1, 1);

GO