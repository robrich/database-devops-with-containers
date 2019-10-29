DEMO SCRIPT
===========

WebSite
-------
AppUser : production

SQL MANAGEMENT STUDIO
---------------------
localhost

BACKUP DATABASE WebApp
TO DISK = 'C:\Users\Rob\Desktop\Database DevOps with Containers\Database\prod-database.bak'
WITH FORMAT,
NAME = 'WebApp';

DOCKER
------
admin command prompt
cd c:\Users\Rob\Desktop\Database DevOps with Containers\Database
docker build -t dev-database .
docker run -p 1433:1433 dev-database

SQL MANAGEMENT STUDIO
---------------------
minikube
sa
D3vP@ssw0rd

USE WebApp
GO
SELECT * FROM dbo.Customer
GO
SELECT * FROM dbo.Settings
GO

WebSite
-------
change connection string, it works
Website's dockerfile
`docker build -t webapp`
`docker-compose up`
environment var made it work
