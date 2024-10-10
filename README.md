# F1App
This branch demos how to add logging with Serilog and Seq to the base application.
In order for this to work, you'll need to have docker and docker compose installed on your machine.
# How to run
The ```docker-compose.yml``` file pulls the Seq image needed and specifies the ports. If you use the specified ports for something else, adjust the settings in the project for your own needs.
1. Run the ```docker-compose.yml``` file with docker compose.
2. Start the yarp gateway with ```dotnet run```
3. Start the Api with ```dotnet run```
