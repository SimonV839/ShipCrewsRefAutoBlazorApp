using ShipCrewsRefAutoBlazorApp.Services;

namespace ShipCrewsRefAutoBlazorApp
{
    public class ShipCrewsService : IShipCrewsService
    {
        ILogger<ShipCrewsService> logger;
        private HttpClient httpClient;
        private ShipCrewClientAuto client;

        public ShipCrewsService(ILogger<ShipCrewsService> logger, HttpClient httpClient)
        {
            this.logger = logger;
            this.httpClient = httpClient;
            client = new ShipCrewClientAuto("https://localhost:7075/", httpClient);
        }

        public Task<SimpleResponse> CreatePerson(PersonHacked body)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponse> DeletePerson(PersonHacked body)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<ICollection<PersonHacked>>> GetAllPeopleAsync()
        {
            try
            {
                var res = await client.PeopleAllAsync();
                return new ServiceResponse<ICollection<PersonHacked>>() { Item = res };
            }
            catch(Exception excep)
            {
                logger.LogError(excep,@"{GetAllPeopleAsync}", nameof(GetAllPeopleAsync));
                return new ServiceResponse<ICollection<PersonHacked>>() { Error = excep.Message };
            }
        }

        public Task<SimpleResponse> UpdatePerson(PersonHacked body)
        {
            throw new NotImplementedException();
        }
    }
}
