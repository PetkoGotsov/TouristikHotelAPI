TouristikHotelAPI

The project is built using latest version of dotnet core 8.0
It is a Rest WebApi including a Swagger UI for querying the endpoints. 
Base model HotelProvider reads a JSON object stored as a static reference in the build. It consists of Hotel array, each containing GuestRoom data.
The HotelRoomService reads the data from the File System as per the appsettings.json definition and makes use of LINQ to filter for specific cases. 
DI is used for injection of ILoggers, IConfiguration and the IHotelRoomService, which is registered as a Singleton in the Service Container.
The code is developed in a way that the endpoints can return:
1) OK result(2xx) when input is provided and matching elements are found.
2) NotFound result(404) when input is provided but no matching elements are found.
3) BadRequest result(400) - makes use of endpoint paramater validation and is returned when no input is provided.

UnitTests

The project is built using NUnit 3.13.3 and Moq 4.20.70
The HotelServiceController dependencies, including the IConfiguration definition (same as TouristikHotelAPI.appsettings.json) are mocked in the Setup method.
It tests the controller's endpoints for successful execution.
