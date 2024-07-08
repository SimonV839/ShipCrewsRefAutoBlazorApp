using ShipCrewsRefAutoBlazorApp.Services;

namespace ShipCrewsRefAutoBlazorApp
{
    public class ShipCrewsService : IShipCrewsService
    {
        private HttpClient httpClient;
        private ShipCrewClientAuto client;

        public ShipCrewsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            client = new ShipCrewClientAuto("https://localhost:7075/", httpClient);
        }

        public Task<SimpleResponse> CreatePerson(Person body)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponse> DeletePerson(Person body)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ICollection<Person>>> GetAllPeopleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponse> UpdatePerson(Person body)
        {
            throw new NotImplementedException();
        }
    }
}
