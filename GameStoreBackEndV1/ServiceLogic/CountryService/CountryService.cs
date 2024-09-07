using AutoMapper;
using GameStoreBackEndV1.ObjectLogic.ObjectDTOs.Country;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;

namespace GameStoreBackEndV1.ServiceLogic.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public CountryService(
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            IMemoryCache memoryCache,
            IMapper mapper
            )
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        public async Task<List<DisplayCountryDto>> GetAllCountriesAsync()
        {
            var displayCountries = _memoryCache.Get<List<DisplayCountryDto>>("country-cache");
            if (displayCountries != null)
            {
                return displayCountries;
            }

            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.GetAsync(_configuration.GetSection("CountryApiUrl").Value);
            var responseBody = await response.Content.ReadAsStringAsync();

            var countryList = JsonConvert.DeserializeObject<List<CountryDto>>(responseBody);

            displayCountries = _mapper.Map<List<DisplayCountryDto>>(countryList);

            var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);
            _memoryCache.Set("country-cache", displayCountries, expirationTime);    // To Check if data is cached using "_memoryCache.Get()"

            return displayCountries;
        }
    }
}
