# Quiz App - ASP.NET Core API

# Prerequisites:
Visual Studio 2022 Community Version: Ensure you have Visual Studio 2022 installed on your machine.

.NET 6 SDK: Make sure you have the .NET 6 SDK installed. You can download it from dotnet.microsoft.com.

# Steps to Run the Application:
# Clone the Repository:

Clone the Quiz App repository to your local machine using the following command:
bash
Copy code
git clone https://github.com/larrybloom/QuizApp.git
Open the Project in Visual Studio:

Navigate to the project directory and open the solution file (QuizApp.sln) in Visual Studio 2022.
Restore Packages:

Once the project is open, right-click on the solution in Solution Explorer and select "Restore NuGet Packages" to ensure all dependencies are restored.
Update Database:

Open the Package Manager Console in Visual Studio (Tools -> NuGet Package Manager -> Package Manager Console).
Run the following commands to apply migrations and update the database:
bash
Copy code
Update-Database
Set Startup Project:

Set the startup project to the API project. Right-click on the quiz-app project and select "Set as StartUp Project."
Run the Application:

Press F5 or click on the "Start" button in Visual Studio to run the application.
This will launch the ASP.NET Core API and open it in your default web browser.

# API Endpoints:

You can explore and test the API endpoints using tools like Swagger. Access Swagger UI by navigating to https://localhost:port/swagger in your browser.
Test the Application:

Use tools like Postman or curl to test the API endpoints or integrate them with a front-end application.

# Additional Notes:
The application uses Entity Framework Core for database operations, so ensure that the database is properly configured and connected.

Check the appsettings.json file for any configuration settings, such as database connection strings.

If you encounter any issues, refer to the project documentation or seek help from the project contributors.

