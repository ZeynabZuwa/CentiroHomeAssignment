# CentiroHomeAssignment

#### Introduction
Hello everybody! :smile: \
I made a Blazor Project with Entity Framework Core where you can import a CSV file

#### Prerequisities
If you want to clone this repository you will need to have 2 things installed on your computer first:
* Visual Studio 
* SQL Server 


#### How to Run the Project

1. Clone the project to Visual Studio
2. Go to CentiroHomeAssignment and go to appsettings.json
3. On DefaultConnection check the Data Source and see if it is the same as your local computer. Mine is .\\SQLEXPRESS so if yours is different then change it to yours.
4. Choose CentiroHomeAssignment as your Startup Project
5. Go to Package Manager Console. Choose CentiroAssignment.Data as your Default project and write in the command: update-database
6. Right click on the Soulution 'CentiroHomeAssignment' and click on Set Startup Projects
7. Choose Multiple startup projects and set CentiroHomeAssignment and CentiroAssignment.UI to Start and press OK.
8. Go to the other window with UI Grid and press on One of the Import Order button (or all of them) to import the CSV files and to save them to the database.
9. go to Show all Orders to see the orders on the UI Grid.
10. Feel free to even try the GET, PUT, DELETE and GET{orderId} in swagger UI to delete, update or get the orders 


## License
[MIT](https://choosealicense.com/licenses/mit/)
