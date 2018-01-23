1. Please install the following pre-requisites:
	- Visual Studio 2017
	- .Net Framework 4.6.1 (installed with Visual Studio)
	- MS Sql Server(preferrably the Developer version) and create an account with root access.
	- MS Sql Management Studio(optional)
2. Open the solution file 'src\ForumApp\ForumApp.sln' inside Visual Studio.
3. Open the 'src\ForumApp\Forum\Infrastructure\ForumApp.Forum.Infrastructure.Persistence\app.config' file and search for the connection string with the name 'DefaultConnection'.
4. Replace the 'User Id' & 'Password' values in the connection string to the credentials that work for MS Sql on your machine. The 'Data Source=.' points to the default instance of MS Sql Server on localhost.
5. Open the 'Package Manager Console' window(View -> Other Windows -> Package Manager Console) and select the project 'ForumApp.Forum.Infrastructure.Persistence' from the 'Default Project' dropdown.
6. Enter the following command in the Package Manager Console and press enter:
	Update-Database
7. Open the 'src\ForumApp\Common\ForumApp.Common.WebHost\web.config' file and search for the connection string with the name 'DefaultConnection'.
8. Replace the 'User Id' & 'Password' values in the connection string to the credentials that work for MS Sql on your machine.
9. Right click the project ForumApp.Common.WebHost in Visual Studio and click 'Restore Nuget packages'.
10. Right click the project ForumApp.Common.WebHost and click 'Rebuild'.
11. Right click the project Forum.Common.WebHost and click 'Debug' -> 'Start a new instance'.