namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class CartDto
    {
        public Guid CartId { get; set; }

        public Guid? PlayerId { get; set; }

        public Guid GameId { get; set; }

        public PlayerDto? Player { get; set; }

        public GameDto Game { get; set; }
    }
}
