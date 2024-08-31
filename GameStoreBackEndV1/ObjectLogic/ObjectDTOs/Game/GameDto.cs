namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class GameDto
    {
        public Guid GameId { get; set; }

        public string Name { get; set; }

        public string GameDetails { get; set; }

        public float Price { get; set; }

        public byte DiscountPercent { get; set; }
    }
}
