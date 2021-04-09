# API_Projects

Please read the below instructions and follow the steps mentioned to configure Web API project named ‘Shop Bridge’ in the system.
Tech Stack: 
•	Database- MS SQL Server 2017
•	IDE- Visual Studio 2017
•	ASP. Net Web API
•	Entity Framework
CRUD operations logic has been implemented in the methods of API using LINQ queries. 
We are using ‘Database approach in order to create First’ Entity Data Model(EDM) as we already have an  existing database with table schema already defined.
Project has separate layer i.e. ‘Data Access layer’ in order to interact with the database. All the methods are implemented in this layer in order to perform CRUD operations using Entity Framework.
All the Web API methods are made asynchronous in order to increase the performance and responsiveness of the application, particularly when there are long-running operations that do not require to block the execution.
Exceptional Handling is also incorporated in the code wherein, if any error is encountered while interacting with database, an exception is thrown back in the response. Also, in case any run time error, code will not break and service will be running fine after handling the exception. 
Authentication logic is also implemented in the application. In order to access Web API methods, client should enter the valid credentials. Client will provide a token which is encoded in 64 base. Service will decode the token and extract the username and password. If credentials match is found, then user will be authenticated. In our case, username is 'Thinkbridge' and password is 'Thinkbridge@123’. If the client enters the valid credentials then only he can consume the Web service. 
Web API exposes below listed methods: 
•	FetchProduct
•	FetchProductById
•	InsertProduct
•	ModifyProduct
•	RemoveProduct

Below steps would be used to create the DB objects in the database required by Web API:
 1.The table ‘Products’ is created in the DB to store the product details.
 PFB the query used to create the table: 
create table Products(ProdId int Identity Primary Key,[Description] varchar(100),Price decimal(10,2),Color varchar(50),WarrantyPeriodInMonths int)

ProdId is a Primary key and in order to generate the ProdId automatically, we have used Identity.
Project files have already been provided in the GitHub and are available at the below path:
Copy the entire project in the server and create all the required DB objects. After configuring the project on the server, run the project and try to access the Web API link to check if the service is up and running fine. 
Database name in the code should match the database name of the server machine where the project is running.

