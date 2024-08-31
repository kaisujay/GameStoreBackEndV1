namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class WishListDto
    {
        public Guid WishListId { get; set; }

        public Guid PlayerId { get; set; }

        public List<Guid> GameId { get; set; }

        public PlayerDto Player { get; set; }

        public List<GameDto> Games { get; set; }
    }
}
