namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class DisplayCartDto
    {
        public Guid CartId { get; set; }

        public Guid? PlayerId { get; set; }

        public DisplayGameDto Games { get; set; }
    }
}
