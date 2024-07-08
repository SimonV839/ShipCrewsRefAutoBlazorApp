namespace ShipCrewsRefAutoBlazorApp.Services
{
    /// <summary>
    /// Provides access to ship crews.
    /// Simon: Note This is based on C:\Users\rapen\Documents\Learning\MSTraining\blazor-samples\8.0\BlazorWebAppCallWebApi_Weather
    /// but this places the service in the client.
    /// </summary>
    public interface IShipCrewsService
    {
        Task<ServiceResponse<ICollection<Person>>> GetAllPeopleAsync();
        Task<SimpleResponse> CreatePerson(Person body);
        Task<SimpleResponse> UpdatePerson(Person body);
        Task<SimpleResponse> DeletePerson(Person body);
    }
}
