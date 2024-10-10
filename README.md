# F1App
An application which demonstates how to use the Repository and Unit of Work pattern, with the help of Swagger for the API. 
Other branches showcase how to integrat this project with MediatR and CQRS, Yarp Gateway, Serilog with Seq for logging.

## How to Run
For other branches, refer to their respective readmes.
Since the solution is split into multiple projects, you need to specify the startup project: ```dotnet ef database update --verbose --project FormulaOne.DataService --startup-project FormulaOne.Api```.

After that, in the project's directory run ```dotnet watch run```.

