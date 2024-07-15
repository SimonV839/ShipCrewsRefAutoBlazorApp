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

        public async Task<SimpleResponse> CreatePersonAsync(PersonHacked body)
        {
            try
            {
                var res = await client.PeoplePOSTAsync(body);
                return new SimpleResponse();
            }
            catch (Exception excep) 
            {
                logger.LogError(excep, @"{CreatePersonAsync}", nameof(CreatePersonAsync));
                return new SimpleResponse() { Error = excep.Message };
            }
        }

        public async Task<SimpleResponse> DeletePersonAsync(PersonHacked body)
        {
            try
            {
                await client.PeopleDELETEAsync(body.PersonId);
                return new SimpleResponse();
            }
            catch (Exception excep)
            {
                logger.LogError(excep, @"{GetAllPeopleAsync}", nameof(GetAllPeopleAsync));
                return new SimpleResponse() { Error = excep.Message };
            }
        }

        public async Task<ServiceResponse<PersonHacked>> AddPersonAsync(PersonHacked person)
        {
            try
            {
                await Task.Delay(1000);// test only
                var res = await client.PeoplePOSTAsync(person);
                return new ServiceResponse<PersonHacked>() { Item = res };
            }
            catch (Exception excep)
            {
                logger.LogError(excep, @"{AddPersonAsync}", nameof(AddPersonAsync));
                return new ServiceResponse<PersonHacked>() { Error = excep.Message };
            }
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

        public async Task<ServiceResponse<ICollection<PersonHacked>>> GetAllPeopleWithLastNameAsync(string lastName)
        {
            try
            {
                /* does not help with refresh problem
                var dummy = GetPersonAsync(0);
                */

                var res = await client.PeopleAllAsync();
                return new ServiceResponse<ICollection<PersonHacked>>() { Item = res?.Where(p => p.LastName.Equals(lastName, StringComparison.InvariantCulture)).ToList() };
            }
            catch (Exception excep)
            {
                logger.LogError(excep, @"{GetAllPeopleAsync}", nameof(GetAllPeopleAsync));
                return new ServiceResponse<ICollection<PersonHacked>>() { Error = excep.Message };
            }
        }

        public async Task<ServiceResponse<PersonHacked>> GetPersonAsync(int id)
        {
            try
            {
                var res = await client.PeopleGETAsync(id);
                return new ServiceResponse<PersonHacked>() { Item = res };
            }
            catch (Exception excep)
            {
                logger.LogError(excep, @"{GetPersonAsync}", nameof(GetPersonAsync));
                return new ServiceResponse<PersonHacked>() { Error = excep.Message };
            }
        }

        public async Task<SimpleResponse> UpdatePersonAsync(PersonHacked body)
        {
            try
            {
                await client.PeoplePUTAsync(body.PersonId, body);
                return new SimpleResponse();
            }
            catch (Exception excep)
            {
                logger.LogError(excep, @"{UpdatePersonAsync}", nameof(UpdatePersonAsync));
                return new SimpleResponse() { Error = excep.Message };
            }
        }
    }
}
