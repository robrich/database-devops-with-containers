Database DevOps with Containers
===============================

This is the companion code for the [Database DevOps with Containers](https://robrich.org/slides/database-devops-with-containers/#/) presentation.

This code demonstrates a containerized database devops pipeline for getting data from a production database into the hands of developers in an automated way.

Usage
-----

### Setup production database

1. Locate a SQL Server of your choice

2. Run each of the files in `Schema` to create the database and all the tables

### Backup production database

1. In your database tool of choice (SSMS, VS Code with mssql, etc), modify this query and run it:

   ```sql
   BACKUP DATABASE WebApp
   TO DISK = '{SET_PATH}\Database\prod-database.bak'
   WITH FORMAT,
   NAME = 'WebApp';
   ```

2. Ensure the `Database` folder contains `prod-database.bak`.

### Run the script that'll build the non-prod container

1. Open a terminal in the `Database` folder.

2. Run this:

   ```sh
   docker build -t dev-database .
   ```

   This script will:

   a. Restore the prod backup
   b. Anonymize, Sanitize, and Shrink the database
   c. Copy into a new container
   d. Save the new container as the tag above

### Use the dev database

1. Launch the container:

   Either:

   Launch `WebAPI/DatabaseDevOps.slnx` in Visual Studio, VS Code, or your IDE of choice

   OR

   Launch the container directly:

   ```sh
   docker run -p 1433:1433 dev-database
   ```

2. Connect to this database using your data query tool of choice:

   - Username: `sa`
   - Password: `D3vP@ssw0rd`

   See `prod-to-dev.sql` where it sets the db password

3. Query the database:

   ```sql
   USE WebApp
   GO
   SELECT * FROM dbo.Customer
   GO
   SELECT * FROM dbo.Settings
   GO
   ```


License
-------

License: MIT
