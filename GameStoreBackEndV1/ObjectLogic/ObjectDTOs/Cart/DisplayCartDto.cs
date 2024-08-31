namespace GameStoreBackEndV1.ObjectLogic.TableDataModels
{
    public class DisplayCartDto
    {
        public Guid CartId { get; set; }

        public DisplayPlayerDto? Player { get; set; }

        public List<DisplayGameDto> Games { get; set; }
    }
}
