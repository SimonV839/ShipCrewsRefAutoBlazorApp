
For auto client code: https://www.code4it.dev/blog/openapi-code-generation-vs2019/

1) Add Server Reference -> OpenAPI: https://localhost:7075/swagger/v1/swagger.json
	note: the generated cs file does not appear in the solution and is placed under obj 
	e.g.: C:\Users\rapen\Documents\Learning\OwnTests\ShipCrewsRefAutoBlazorApp\ShipCrewsRefAutoBlazorApp\ShipCrewsRefAutoBlazorApp\obj\swaggerClient.cs

	the code can be viewed by double clicking Connected Services which will open a tab
	and then ... -> View generated code

2) Create a shipcrews service for injection (as in C:\Users\rapen\Documents\Learning\MSTraining\blazor-samples\8.0\BlazorWebAppCallWebApi_Weather)

3) Add the People page.