# TvMazeScraper

## Running the application

I decided to use SQLite for this assignment because this way it is easier to (re)-create the database. This also means you do not need to run a database server locally. 

Following commands should be everything needed to fire up the application.

- dotnet restore
- dotnet ef database update
- dotnet run

After starting the application it should directly start scraping data in the background. 

Data is made available through http://localhost:5000/api/v1/shows?page=1&perpage=5

