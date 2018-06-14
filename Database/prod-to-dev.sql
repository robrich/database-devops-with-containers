USE [master]
GO
RESTORE DATABASE [WebApp] FROM DISK = '/tmp/prod-database.bak'
WITH FILE = 1,
MOVE 'WebApp' TO '/var/opt/mssql/data/webapp.mdf',
MOVE 'WebApp_Log' TO '/var/opt/mssql/data/webapp.ldf',
NOUNLOAD, REPLACE, STATS = 5
GO
USE [WebApp]
-- Sanitize data
UPDATE dbo.Customer SET Email = CAST(NEWID() as nvarchar(50)) + '@contoso.com'
-- Fake user data from https://randomuser.me/
GO
UPDATE dbo.Settings SET [Secret] = 'dev-safe' WHERE Name = 'ApiKey'
GO
UPDATE dbo.Settings SET [Secret] = CAST(GETDATE() as nvarchar(50)) WHERE Name = 'BuildDate'

-- Shrink data size
DELETE FROM dbo.InvoiceLog WHERE 1 = 0
GO

-- Truncate log file
ALTER DATABASE WebApp
SET RECOVERY SIMPLE;
GO
-- Shrink database
DBCC SHRINKFILE (N'WebApp' , 1) WITH NO_INFOMSGS -- 1 is size in mb
GO
-- Shrink the truncated log file
DBCC SHRINKFILE (N'WebApp_Log', 1) WITH NO_INFOMSGS -- 1 is size in mb
GO

-- Solve orphaned user, set dev password
EXEC sp_change_users_login 'Auto_Fix', 'AppUser', NULL, 'D3vP@ssw0rd'
GO
ALTER LOGIN SA WITH PASSWORD='D3vP@ssw0rd'
GO
