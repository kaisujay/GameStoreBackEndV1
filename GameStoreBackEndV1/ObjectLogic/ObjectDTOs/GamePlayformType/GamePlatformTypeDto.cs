namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class GamePlatformTypeDto
    {
        public Guid GameId { get; set; }

        public Guid PlatformTypeId { get; set; }
        
        public DisplayGameDto Game { get; set; }
        
        public PlatformTypeDto PlatformType { get; set; }
    }
}
