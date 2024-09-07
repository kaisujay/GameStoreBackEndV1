using AutoMapper;
using GameStoreBackEndV1.ObjectLogic.ObjectDTOs.Country;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;

namespace GameStoreBackEndV1.ServiceLogic.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public CountryService(
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            IMapper mapper
            )
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<List<DisplayCountryDto>> GetAllCountriesAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync(_configuration.GetSection("CountryApiUrl").Value);
            var responseBody = await response.Content.ReadAsStringAsync();

            var countryList = JsonConvert.DeserializeObject<List<CountryDto>>(responseBody);

            var displayCountries = _mapper.Map<List<DisplayCountryDto>>(countryList);

            return displayCountries;
        }
    }
}
