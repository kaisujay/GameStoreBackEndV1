namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class OrderHistoryDto
    {
        public Guid OrderHistoryId { get; set; }

        public Guid OrderId { get; set; }

        public Guid PlayerId { get; set; }

        public Guid GameId { get; set; }

        public PlayerDto Player { get; set; }

        public GameDto Games { get; set; }

        public DateTime PurchaseDate { get; set; }

        public float PurchaseAmmount { get; set; }
    }
}
