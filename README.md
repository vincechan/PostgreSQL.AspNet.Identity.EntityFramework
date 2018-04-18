# PostgreSQL.AspNet.Identity.EntityFramework

ASP.NET Identity 2.0 provider that use Entity Framework for PostgreSQL.

## How to use in a ASP.NET MVC5 template project

### 1. Set up Entity Framework for PostgreSQL
1. Install the Npgsql.EntityFramework nuget package
2. Update the web.config
  
  ```xml
  <entityFramework>
    <defaultConnectionFactory type="Npgsql.NpgsqlFactory, Npgsql" />
    <providers>
      <provider invariantName="Npgsql" type="Npgsql.NpgsqlServices, Npgsql.EntityFramework" />
    </providers>
  </entityFramework>
  
  <system.data>
    <DbProviderFactories>
      <add name="Npgsql Data Provider" invariant="Npgsql" support="FF" description=".Net Framework Data Provider for Postgresql" type="Npgsql.NpgsqlFactory, Npgsql" />
    </DbProviderFactories>
  </system.data>  
  ```
3. Update the ConnectionString
  
  ```xml
  <connectionStrings>
    <add name="DefaultConnection" connectionString="Server=localhost;Database=[your_db_name];User Id=[your_user];Password=[your_password];SearchPath=public;" providerName="Npgsql" />
  </connectionStrings>
  ```
  
You do not have to use "DefaultConnection" as the name. If you use a different name, just specify the name in the nameOrConnectionString parameter in the DbConext constructor.

Specify SearchPath in the connection string to specify the schema for the Identity tables. By default, it will use public.

### 2. Update the project to use PostgreSQL.AspNet.Idnetity.EntityFramework
Once you have correctly setup the PostgreSQL EntityFramework, using PostgreSQL.AspNet.Identity.Framework is straight forward.

1. Add the PostgreSQL.AspNet.Identity.EntityFramework project as a reference
2. Remove the Microsoft.AspNet.Identity.EntityFramework nuget package and replace the "using Microsoft.AspNet.Identity.EntityFramework" statements with "using PostgreSQL.AspNet.Identity.EntityFramework" (it's in IdentityModel.cs and IdentityConfig.cs in the default mvc5 project template)
   
### 3. Use without Migration
The default database initalizer is CreateDatabaseIfNotExists. It will automatically create the database if one does not exist and it will also enable database migration. To turnoff off migration

1. Run the PostgreSQLIdentity.sql script to create the identity tables in your postgreSQL database. We have to do this since the identity tables will not be created automatically.
2. Set the database initalizer to NullDatabaseInitializer to turn off migration.

```csharp
// put this in the project startup 
Database.SetInitializer<ApplicationDbContext>(new NullDatabaseInitializer<ApplicationDbContext>());
```

## Demo Project
An ASP.NET MVC5 template project is included to show it in action. To run the demo project, update the web.config DefaultConnection connection string. 

Note. Specify a database name that does not exist to have it create the database automatically for you. Alterntively if you wish to turn off migration, follow step 3 above.

## References
* This is a port of the [ASPNET Identity for SQL Server](https://aspnetidentity.codeplex.com/). 
* This project got a jump start from [AspNet.Identity.PostgreSQL](https://github.com/danellos/AspNet.Identity.PostgreSQL)

## LICENSE
[MIT](/LICENSE)
