# 24-Hour-Code-Challenge
24 Hour Code Challenge mini project for Ehrlich

# Getting Started
1.	Programming language, frameworks and libraries
	- .Net 8
	- Entity Framework
    - CQRS Design Pattern
2.	Latest releases
	- main branch

# Build and run the project
- Create new database in sql server.
- Choose any method below for creating a database table:
	- Deploy the database project **(PizzaSales.Database)** in the solutions by specifying the SQL Server version in the properties before publishing.
	- Run the SQL script included in the repository named **dbScripts.sql**.
- Import the **Postman Collection** included in the repository named **Ehrlich Challenge.postman_collection.json**.
- Run the project
    - Change the **ConnectionString** in appSettings.json
    - Run the **(PizzaSales.API)** project
	- Execute the Get Access Token using Postman (client ID and client secret is in the app settings of the project).
		- The access token in the result can be use in all of the endpoints.
- Establish the database table data for referencing in the API.
    - In the Orders and Pizzas folder:
        - **Add Batch Orders**, **Add Batch Order Details**, **Add Batch Pizzas**, **Add Batch Pizza Types**
        - Configure the body and select file from your local machine and execute
- Explore all the API endpoints for Get Orders and Insights.