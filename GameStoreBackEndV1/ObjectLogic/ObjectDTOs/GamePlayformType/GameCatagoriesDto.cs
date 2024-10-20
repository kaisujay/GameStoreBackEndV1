using Swashbuckle.AspNetCore.SwaggerGen;

namespace GameStoreBackEndV1.ObjectLogic.ObjectDTOs.GamePlayformType
{
    public class GameCategoriesDto
    {
        public Dictionary<Platforms, int> Categories { get; set; }
    }

    public enum Platforms
    {
        All,
        PC,
        Xbox,
        PlayStation
    }
}
