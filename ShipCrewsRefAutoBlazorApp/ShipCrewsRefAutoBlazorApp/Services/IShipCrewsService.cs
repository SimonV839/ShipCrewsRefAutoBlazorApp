namespace ShipCrewsRefAutoBlazorApp.Services
{
    /// <summary>
    /// Provides access to ship crews.
    /// Simon: Note This is based on C:\Users\rapen\Documents\Learning\MSTraining\blazor-samples\8.0\BlazorWebAppCallWebApi_Weather
    /// but this places the service in the client.
    /// </summary>
    public interface IShipCrewsService
    {
        Task<ServiceResponse<ICollection<PersonHacked>>> GetAllPeopleAsync();

        //  Added because filtering after the await seems to cause a problem with refresh
        Task<ServiceResponse<ICollection<PersonHacked>>> GetAllPeopleWithLastNameAsync(string lastName);
        Task<ServiceResponse<PersonHacked>> GetPersonAsync(int id);
        Task<SimpleResponse> CreatePersonAsync(PersonHacked body);
        Task<SimpleResponse> UpdatePersonAsync(PersonHacked body);
        Task<SimpleResponse> DeletePersonAsync(PersonHacked body);
        Task<ServiceResponse<PersonHacked>> AddPersonAsync(PersonHacked person);
    }
}
