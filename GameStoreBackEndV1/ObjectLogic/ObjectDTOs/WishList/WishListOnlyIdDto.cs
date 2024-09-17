namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class WishListOnlyIdDto
    {
        public Guid WishListId { get; set; }

        public Guid PlayerId { get; set; }

        public Guid GameId { get; set; }
    }
}
