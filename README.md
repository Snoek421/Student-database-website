# Student-database-website
ASP.NET MVC Web app made to manage a simple database of students enrollment and status at a school


Requires a local SQL server to work.

### Steps to run in VS2022:
1. Make sure server connection string in appsettings.json points towards your local SQL server (by default the value is `localhost\\SQLEXPRESS`, but it can be changed to fit your server connection)
2. Open PowerShell terminal in the `Assignment 1` directory, run `dotnet restore`, and then run `dotnet ef database update`. If this fails, make sure that the EF core packages have been installed and restored, and ensure that the entity framework core tools package is installed globally if necessary.
3. Ensure the command runs successfully and the database is created correctly in your database.
4. Debug/Run without debugging to open web browser and connect to locally hosted server.

### Other notes:
1. Make sure your SQL server or service is running and configured correctly to allow the project's connection.
2. If using a different database, you may need to add other nuget packages. This was built using Microsoft SQL Server running locally on the development machine.


## License Choice
I selected a BSD 3-Clause License for this project, because it is simple but effective and covers all the things I think should be neccessary for this simple of a project.
Redistribution of the source code or binary compiled code must include my copyright notice, which to my understanding should prevent other students or programmers from having permission to take my code and present it as their own, whether that be in an assignment or as a standalone project. Because this was a simple project made for an assignment, my main concern for this code would be other studens finding and copying my work while I'm still in college and getting an academic offense because somebody copied and submitted it as their own. That being said, I have no issue with people taking and using this code because it is nothing special to me and is laregly simple basic functionality. 
This license seemed to allow those permissions while preventing others from "stealing" my work, so it fit the project's needs.
