using GameStoreBackEndV1.ObjectLogic.ObjectDTOs.Country;

namespace GameStoreBackEndV1.ServiceLogic.CountryService
{
    public interface ICountryService
    {
        Task<List<DisplayCountryDto>> GetAllCountriesAsync();
    }
}