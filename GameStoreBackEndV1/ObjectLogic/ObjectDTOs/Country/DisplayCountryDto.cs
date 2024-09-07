using Newtonsoft.Json;

namespace GameStoreBackEndV1.ObjectLogic.ObjectDTOs.Country
{
    public class DisplayCountryDto
    {
        public string? Name { get; set; }
        
        public bool? Independent { get; set; }

        public Currency? Currency { get; set; }

        public string? Region { get; set; }
        
        public string? GoogleMaps { get; set; }
        
        public long? Population { get; set; }
        
        public string[]? TimeZones { get; set; }
        
        public string? Flag { get; set; }
    }

    public  class Currency
    {
        public string? Name { get; set; }

        public string? Symbol { get; set; }
    }
}
