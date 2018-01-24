1. Please install the following pre-requisites:
	- Visual Studio 2017
	- .Net Framework 4.6.1 (installed with Visual Studio)
	- MS Sql Server(preferrably the Developer version) and create an account with root access.
	- MS Sql Management Studio(optional)
2. Open the solution file 'src\ForumApp\ForumApp.sln' inside Visual Studio.
3. In the following files, search for the connection string with the name 'DefaultConnection' and replace the 'User Id' & 'Password' values in the connection string to the credentials that work for MS Sql Server on your machine. Replacing it in the first 2 files is mandatory, the rest of the files are used for test cases so modifying their app.config is optional in case you want to run the Unit tests:
	src\ForumApp\Common\ForumApp.Common.WebHost\web.config
	src\ForumApp\Forum\Infrastructure\ForumApp.Forum.Infrastructure.Persistence\app.config
	
	src\ForumApp\Forum\Infrastructure\ForumApp.Forum.Infrastruc.Persist.Tests\App.config
	src\ForumApp\Forum\Application\ForumApp.Forum.Application.Tests\app.config
	src\ForumApp\Forum\Ports\ForumApp.Forum.Ports.Rest.Tests\App.config
	
	The 'Data Source=.' in the DefaultConnection connection string points to the default instance of MS Sql Server on localhost.
4. Open the 'Package Manager Console' window(View -> Other Windows -> Package Manager Console) and select the project 'ForumApp.Forum.Infrastructure.Persistence' from the 'Default Project' dropdown.
5. Enter the following command in the Package Manager Console and press enter:
	Update-Database
6. Right click the project ForumApp.Common.WebHost in Visual Studio and click 'Restore Nuget packages'.
7. Right click the project ForumApp.Common.WebHost and click 'Rebuild'.
8. Right click the project Forum.Common.WebHost and click 'Debug' -> 'Start a new instance'.