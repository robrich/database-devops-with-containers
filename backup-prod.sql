USE WebApp
GO
SELECT * FROM dbo.Customer
GO
SELECT * FROM dbo.InvoiceLog
GO
SELECT * FROM dbo.Settings
GO


BACKUP DATABASE WebApp
TO DISK = 'C:\Users\Rob\Desktop\Database DevOps with Containers\Database\prod-database.bak'
WITH FORMAT,
NAME = 'WebAppBackup';
