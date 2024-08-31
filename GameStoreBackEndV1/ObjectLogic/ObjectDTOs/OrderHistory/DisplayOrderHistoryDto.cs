namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class DisplayOrderHistoryDto
    {
        public Guid OrderHistoryId { get; set; }

        public DisplayPlayerDto Player { get; set; }

        public List<DisplayGameDto> Games { get; set; }

        public DateTime PurchaseDate { get; set; }

        public float PurchaseAmmount { get; set; }
    }
}
